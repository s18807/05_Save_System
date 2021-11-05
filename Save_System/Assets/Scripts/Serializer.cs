using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Serializer
{
    private static string path = Application.persistentDataPath + "save1.sav";

    public static void Save()
    {
        BinaryFormatter formatter = GetBinaryFormatter();
        FileStream file = File.Create(path);
        formatter.Serialize(file, SaveData.instance);
        file.Close();
    }

    public static object Load()
    {
        if (!File.Exists(path))
            return null;
        BinaryFormatter formatter = GetBinaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);
        try
        {
            object save = formatter.Deserialize(file);
            file.Close();
            return save;
        } catch
        {
            file.Close();
            return null;
        }
    }

    public static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        SurrogateSelector selector = new SurrogateSelector();
        Vector3SerializationSurrogate v3surrogate = new Vector3SerializationSurrogate();
        selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), v3surrogate);

        formatter.SurrogateSelector = selector;
        return formatter;
    }
}

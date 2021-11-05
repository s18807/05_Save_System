using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public Text text;
    void Update()
    {
        if(Input.GetKeyDown("p"))
        {
            SaveData.instance.playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            Serializer.Save();
        }
        if(Input.GetKeyDown("o"))
        {
            SaveData.instance = (SaveData) Serializer.Load();
            Debug.Log(SaveData.instance.playerPosition);
            GameObject.FindGameObjectWithTag("Player").transform.position = SaveData.instance.playerPosition;
            text.text = "Gold: " + SaveData.instance.gold + ", Potions: " + SaveData.instance.potions;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    private static SaveData _instance;

    public int gold, potions,health;
    public Vector3 playerPosition;
    public Vector3[] Coins;
    public Vector3[] Potions;
    public Vector3[] Enemies;
    public static SaveData instance
    {
        get {
            if (_instance == null)
            {
                _instance = new SaveData();
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }


}

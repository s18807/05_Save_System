using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public Text text;
    public GameObject Potion;
    public GameObject Coin;
    public GameObject Enemy;
    void Update()
    {
        if(Input.GetKeyDown("["))
        {
            SaveData.instance.playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            GameObject[] g = GameObject.FindGameObjectsWithTag("Coin");
            Vector3[] x = new Vector3[g.Length];
            for (int i = 0; i < g.Length; i++) {
                x[i] = g[i].transform.position;
            }

            SaveData.instance.Coins = x;
            g = GameObject.FindGameObjectsWithTag("Potion");
            x = new Vector3[g.Length];
            for (int i = 0; i < g.Length; i++)
            {
                x[i] = g[i].transform.position;
            }
            SaveData.instance.Potions = x;
            g = GameObject.FindGameObjectsWithTag("Enemy");
            x = new Vector3[g.Length];
            for (int i = 0; i < g.Length; i++)
            {
                x[i] = g[i].GetComponent<EnemyController>().StartPos;
            }
            SaveData.instance.Enemies = x;

            Serializer.Save();

        }
        if(Input.GetKeyDown("]"))
        {
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Coin"))
            {
                Destroy(g);
            }
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Potion"))
            {
                Destroy(g);
            }
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(g);
            }
            

            SaveData.instance = (SaveData) Serializer.Load();
            Debug.Log(SaveData.instance.playerPosition);
            GameObject.FindGameObjectWithTag("Player").transform.position = SaveData.instance.playerPosition;
            foreach (Vector3 vector3 in SaveData.instance.Potions) {
                GameObject g = Instantiate(Potion, vector3,Quaternion.identity);
                g.GetComponent<Potion>().Text = text;
            }
            foreach (Vector3 vector3 in SaveData.instance.Coins)
            {
                GameObject g = Instantiate(Coin, vector3, Quaternion.identity);
                g.GetComponent<Coin>().Text = text;
            }
            foreach (Vector3 vector3 in SaveData.instance.Enemies)
            {
                GameObject g = Instantiate(Enemy, vector3, Quaternion.identity);
                g.GetComponent<EnemyController>().StartPos = vector3;
                g.GetComponent<EnemyController>().Speed = 1;
                g.GetComponent<EnemyController>().MoveRange = 0.5f;
                g.GetComponent<EnemyController>().Text = text;
            }
            text.text = "Gold: " + SaveData.instance.gold + ", Potions: " + SaveData.instance.potions + ", Health: " + SaveData.instance.health;
        }
    }
}

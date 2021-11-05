using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{
    [SerializeField] private Text text;

    public Text Text { get => text; set => text = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            SaveData.instance.potions++;
        text.text = "Gold: " + SaveData.instance.gold + ", Potions: " + SaveData.instance.potions + ", Health: " + SaveData.instance.health;
        Destroy(gameObject);
    }
}

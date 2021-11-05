using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float moveRange;
    [SerializeField] private Text text; 
    private Vector3 startPos;

    public Vector3 StartPos { get => startPos; set => startPos = value; }
    public float Speed { get => speed; set => speed = value; }
    public float MoveRange { get => moveRange; set => moveRange = value; }
    public Text Text { get => text; set => text = value; }

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position +Vector3.right* speed * Time.deltaTime;
        if (transform.position.x > startPos.x + moveRange || transform.position.x < startPos.x - moveRange) speed = -speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            SaveData.instance.health--;
        text.text = "Gold: " + SaveData.instance.gold + ", Potions: " + SaveData.instance.potions + ", Health: " + SaveData.instance.health;
        Destroy(gameObject);
    }
}

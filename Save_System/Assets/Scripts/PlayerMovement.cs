using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Text text;
    public float moveSpeed, jumpSpeed;
    [SerializeField]private bool grounded = false;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        SaveData.instance.health=3;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            animator.SetTrigger("jump");
        }
        float xDisplacement = Input.GetAxis("Horizontal");
        if (xDisplacement < 0)
            sr.flipX = false;
        if (xDisplacement > 0)
            sr.flipX = true;
        animator.SetFloat("xSpeed", Mathf.Abs(xDisplacement));
        rb.velocity = new Vector2(xDisplacement * moveSpeed, rb.velocity.y);
        
        if (Input.GetButtonDown("Fire1")&& SaveData.instance.potions>0) {
            SaveData.instance.potions--;
            SaveData.instance.health++;
            text.text = "Gold: " + SaveData.instance.gold + ", Potions: " + SaveData.instance.potions + ", Health: " + SaveData.instance.health;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            animator.SetBool("grounded", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
            animator.SetBool("grounded", false);
        }
    }
}

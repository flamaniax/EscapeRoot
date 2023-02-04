using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb; //this is a rigidbody, which we will use to move the character around, and use for our physics system
    public float gravity,jumpHeight,Speed;

    public SpriteRenderer PlayerSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")) //this is the old input system for Unity. 
        {
            Debug.Log("Jump");
            rb.velocity += new Vector2(0,jumpHeight);
        }
        
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed,rb.velocity.y);

        if(rb.velocity.x < 0)
        {
            PlayerSprite.flipX = true;
        }
        else
        {
            PlayerSprite.flipX = false;
        }

        rb.velocity += new Vector2(0,-gravity) * Time.deltaTime;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
    }
}

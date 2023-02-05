using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb; //this is a rigidbody, which we will use to move the character around, and use for our physics system
    public float gravity,jumpHeight,Speed,ClimbingSpeed;

    public int totalJumpCount;
    int jumpCount;

     public float distance;
     public LayerMask DirtCheck;
    public SpriteRenderer PlayerSprite;

    public AudioScript DigEffect;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("HasControl",1);
        jumpCount = totalJumpCount;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Aimdir = new Vector2(Input.GetAxis("Horizontal"), 0);
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Aimdir,distance,DirtCheck); 

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("application quitting!");
            Application.Quit();
        }

        if(PlayerPrefs.GetInt("HasControl") == 1)
        {
            if(Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Horizontal") != 0)
            {

                if(hit.collider.gameObject != null)
                {
                    rb.velocity = new Vector2(0,Input.GetAxis("Vertical") * ClimbingSpeed);
                }
                else
                {
                    BaseMovement();
                }
                
            }
            else
            {
                BaseMovement();
            }

            
        }

        
    }

    void BaseMovement()
    {
        if(Input.GetKeyDown("space") && jumpCount > 0) //this is the old input system for Unity. 
        {
            Debug.Log("Jump");
            rb.velocity += new Vector2(0,jumpHeight);
            DigEffect.PlayJump();
            jumpCount -= 1;
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
        Vector2 DirectionVector = transform.position - col.transform.position;
        if(DirectionVector.y > 0)
        {
            Debug.Log(DirectionVector);
            jumpCount = totalJumpCount;
        }
    }
}

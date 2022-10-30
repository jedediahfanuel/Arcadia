using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // public float jumpforce = 10f;
    // Rigidbody2D rb;
    // public int JumpCount = 1;
    // Collider2D coll;
    // bool isGrounded;
    // void Start()
    // {
    //     rb = GetComponent<Rigidbody2D>();
    //     coll = GetComponent<Collider2D>();
    // }

    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //         {
    //             // GroundCheck();
    //             rb.AddForce(Vector2.up * jumpforce,ForceMode2D.Impulse);
                
    //         }
    // }
    // // void Update () {
    // //     rigidbody2D.AddForce (Vector2.right * 10);
    // // }
 
    // public void GroundCheck(){
    //     rb.AddForce(Vector2.up * jumpforce,ForceMode2D.Impulse);
    //     if (coll.gameObject.name == "grave" && JumpCount == 1) {     
    //         // GetComponent<Rigidbody2D>().velocity = transform.up * 10;
    //         rb.AddForce(Vector2.up * jumpforce,ForceMode2D.Impulse);
    //         JumpCount = JumpCount - 1;
    //     } else if (coll.gameObject.name == "grave" && JumpCount == 0) {
    //         JumpCount = JumpCount + 1;       
    //     }        
    // }
    public float jumpSpeed = 12;
    public Rigidbody2D rb;
    public GameObject gameObject;
    bool isGrounded;
    Vector3 movement;
    int c;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        c = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            DoJump();
        }
    }

    void DoJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
            if(c  > 0 ) {
                c = c - 1;
            } else {
                isGrounded  = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "grave")
        {
            isGrounded = true;
            c = 1;
        }
    }
}

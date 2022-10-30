using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpSpeed = 12;
    public Rigidbody2D rb;
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

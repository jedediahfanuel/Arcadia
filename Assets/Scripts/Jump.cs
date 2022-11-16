using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpSpeed = 18;
    public Rigidbody2D rb;
    bool isGrounded;
    Vector3 movement;
    int c;
    bool isUpsideDown = false;
    public float moveSpeed = 10;
    GameObject suv;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        c = 1;
        suv = GameObject.Find("suv");
    }

    GameObject particle;
    // Update is called once per frame
    void Update()
    {   
        if(suv.transform.rotation.z == -1)
        {
            isUpsideDown = true;
        }
        // Debug.Log(suv.transform.rotation.z);
        if (isUpsideDown == false) 
        {
            if (isGrounded)
            {
                DoJump();
                DoJumpByTouch();
            }
        } else {
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }
    }

    void DoJumpByTouch()
    {
        foreach(Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                rb.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
                if (c > 0) {
                    c = c - 1;
                } else {
                    isGrounded = false;
                }
            }
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

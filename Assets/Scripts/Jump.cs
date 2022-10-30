using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpforce = 10f;
    Rigidbody2D rb;
    public int JumpCount = 1;
    Collider2D coll;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            {
                // GroundCheck();
                rb.AddForce(Vector2.up * jumpforce,ForceMode2D.Impulse);
                
            }
    }
    // void Update () {
    //     rigidbody2D.AddForce (Vector2.right * 10);
    // }
 
    public void GroundCheck(){
        rb.AddForce(Vector2.up * jumpforce,ForceMode2D.Impulse);
        if (coll.gameObject.name == "grave" && JumpCount == 1) {     
            // GetComponent<Rigidbody2D>().velocity = transform.up * 10;
            rb.AddForce(Vector2.up * jumpforce,ForceMode2D.Impulse);
            JumpCount = JumpCount - 1;
        } else if (coll.gameObject.name == "grave" && JumpCount == 0) {
            JumpCount = JumpCount + 1;       
        }        
    }
}

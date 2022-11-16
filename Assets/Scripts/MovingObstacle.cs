using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rb;
    Vector3 movement;
    public float moveSpeed = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // suv = GameObject.Find("suv"); 
        if(collision.gameObject.name == "suv")
        {
            Vector2 direction = collision.GetContact(0).normal;
            if( direction.x > 0.9 ) Debug.Log("Game over");
        }
    }
}

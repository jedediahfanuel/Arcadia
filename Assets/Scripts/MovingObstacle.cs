using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rb;
    public float moveSpeed = 10;
    private float leftBound = -30;
    Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        DestroyObstacleExitCamera();
    }

    private void DestroyObstacleExitCamera()
    {
        if (transform.position.x < leftBound) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // player = GameObject.Find("player"); 
        if (collision.gameObject.name == "player")
        {
            Vector2 direction = collision.GetContact(0).normal;
            if( direction.x > 0.9 ) Debug.Log("Game over");
        }
    }
}

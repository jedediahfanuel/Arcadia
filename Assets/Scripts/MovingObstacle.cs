using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed = 10;
    private float leftBound = -30;
    Vector3 movement;
    private GameManager gameManager;
    private Perks perks;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        perks = GameObject.Find("PowerUp").GetComponent<Perks>();
    }

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
        if (collision.gameObject.name == "player")
        {
            if (perks.GetIsHealth())
            {
                Destroy(gameObject);
            }
            else
            {
                Vector2 direction = collision.GetContact(0).normal;
                if (direction.x > 0.9) gameManager.EndOfStage();
            }
        }
    }
}

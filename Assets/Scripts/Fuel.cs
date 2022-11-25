using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    public Rigidbody2D rb;
    private float leftBound = -30;
    public float moveSpeed = 10;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        DestroyObstacleExitCamera();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            gameManager.PlayFuelSound();
            gameManager.UpdateScore(1);
            Destroy(gameObject);
        }
    }

    private void DestroyObstacleExitCamera()
    {
        if (transform.position.x < leftBound) Destroy(gameObject);
    }
}

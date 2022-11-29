using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    public Rigidbody2D rb;
    private float leftBound = -30;
    public float moveSpeed = 10;
    private GameManager gameManager;
    HealthBar hb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        hb = GameObject.Find("UI ProgressBar").GetComponent<HealthBar>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        DestroyFuelExitCamera();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            gameManager.PlayFuelSound();
            gameManager.UpdateScore(1);
            hb.AddProgressBar(5);
            Destroy(gameObject);
        }
    }

    private void DestroyFuelExitCamera()
    {
        if (transform.position.x < leftBound) Destroy(gameObject);
    }
}

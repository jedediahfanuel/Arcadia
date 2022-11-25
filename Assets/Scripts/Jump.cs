using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpSpeed = 25;
    public Rigidbody2D rb;
    bool isGrounded;
    Vector3 movement;
    int c;
    bool isUpsideDown = false;
    public float moveSpeed = 10;
    GameObject player;
    private AudioSource audioSource;
    float elapsed = 0f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        c = 1;
        player = GameObject.Find("player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        audioSource = GetComponent<AudioSource>();
        CheckAudioSource();
    }

    private void CheckAudioSource()
    {
        if (audioSource == null) Debug.LogError("The audio source in the -player- is NULL || the audio source commponent have not been added before");
    }

    GameObject particle;
    // Update is called once per frame
    void Update()
    {   
        if(player.transform.rotation.z == -1)
        {
            isUpsideDown = true;
        }
        // Debug.Log(player.transform.rotation.z);
        if (isUpsideDown == false) 
        {
            if (isGrounded)
            {
                DoJump();
                DoJumpByTouch();
            }
            elapsed += Time.deltaTime;
            if (elapsed >= 1f) {
                elapsed = elapsed % 1f;
                gameManager.UpdateScore(1);
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
                rb.AddForce(new Vector2(0f, jumpSpeed - rb.velocity.y), ForceMode2D.Impulse);
                audioSource.Play();

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
            rb.AddForce(new Vector2(0f, jumpSpeed - rb.velocity.y), ForceMode2D.Impulse);
            Debug.Log(rb.velocity);
            audioSource.Play();
            
            if (c > 0) {
                c = c - 1;
            } else {
                isGrounded  = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "ground")
        {
            isGrounded = true;
            c = 1;
        }
    }
}

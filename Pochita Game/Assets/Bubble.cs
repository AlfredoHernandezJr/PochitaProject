using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public Vector2 BubblePosition;
    public Vector2 FinalBubblePosition;
    public GameObject player;
    public GameObject pop;
    bool isMovingUp = false;
    float customDeltaTime = 0.004f;

    private float originalGravityScale;

    void Start()
    {
        BubblePosition = transform.position;
    }

    void Update()
    {
        if (isMovingUp)
        {
            transform.Translate(Vector2.up * customDeltaTime * 20);

            // Update the player's position to follow the bubble and be centered
            if (player != null)
            {
                player.transform.position = new Vector2(transform.position.x, transform.position.y);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;

            if (player != null)
            {
                // Store the original gravity scale
                Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    originalGravityScale = playerRb.gravityScale;
                }

                // Move the player to the bubble position and center it
                player.transform.position = new Vector2(transform.position.x, BubblePosition.y);

                // Disable gravity for the player's Rigidbody component
                if (playerRb != null)
                {
                    playerRb.gravityScale = 0f;
                }

                isMovingUp = true;
            }
        }
        else if (other.CompareTag("Pop"))
        {
            if (other.gameObject == pop)
            {
                FinalBubblePosition = transform.position;
                isMovingUp = false;
                transform.position = BubblePosition;
                player.transform.position = FinalBubblePosition;

                // Enable gravity for the player's Rigidbody component
                Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    playerRb.gravityScale = originalGravityScale;
                }
            }
        }
    }
}


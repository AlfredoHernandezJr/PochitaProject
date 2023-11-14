using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public float speed = 7.0f; // You can adjust the speed to your liking
    public float jumpForce = 10f; // Initial force of the jump
    public float maxJumpHeight = 15f; // Maximum jump height
    private float initialY; // Initial y-position when the jump starts
    private bool isJumping = false; // Whether the character is currently jumping
    private Rigidbody2D rb;
    private Vector3 initialScale; // Initial scale of the sprite

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialScale = transform.localScale; // Store the initial scale
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f;

        if (Input.GetKey("a"))
        {
            moveX = -speed;
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z); // Flip sprite to face left
        }
        if (Input.GetKey("d"))
        {
            moveX = speed;
            transform.localScale = initialScale; // Flip sprite to face right
        }

        rb.velocity = new Vector2(moveX, rb.velocity.y);

        if (Input.GetKeyDown("w") && !isJumping)
        {
            isJumping = true;
            initialY = transform.position.y;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if (isJumping && transform.position.y - initialY >= maxJumpHeight)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }

    // This method is called when the character touches the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
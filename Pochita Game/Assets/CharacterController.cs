using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public float speed = 7.0f;
    public float jumpForce = 10f;
    public float maxJumpHeight = 15f;
    [SerializeField] private float dashingVelocity = 10f;
    [SerializeField] private float dashingTime = 0.5f;
    private Vector2 dashingDir;
    public bool isDashing;
    private bool canDash = true;

    private float initialY;
    private bool isJumping = false;
    private Rigidbody2D rb;
    private Vector3 initialScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialScale = transform.localScale;
    }

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey("a"))
        {
            moveX = -speed;
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }
        if (Input.GetKey("d"))
        {
            moveX = speed;
            transform.localScale = initialScale;
        }
        if (Input.GetKey("w"))
        {
            moveY = speed;
        }
        if (Input.GetKey("s"))
        {
            moveY = -speed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            initialY = transform.position.y;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if (isJumping && transform.position.y - initialY >= maxJumpHeight)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            isDashing = true;
            canDash = false;
            dashingDir = new Vector2(moveX, moveY);
            StartCoroutine(StopDashing());
        }

        if (isDashing)
        {
            rb.velocity = dashingDir.normalized * dashingVelocity;
            return;
        }

        rb.velocity = new Vector2(moveX, rb.velocity.y);
    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            canDash = true;
        }
    }
}
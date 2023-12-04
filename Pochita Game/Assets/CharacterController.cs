using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movementScript : MonoBehaviour
{
    public float speed = 7.0f;
    public float jumpForce = 10f;
    public float maxJumpHeight = 15f;
    [SerializeField] private float dashingVelocity = 10f;
    [SerializeField] private float dashingTime = 0.5f;
    [SerializeField] private float dashCooldown = 2f;
    private Vector2 dashingDir;
    public bool isDashing;
    private bool canDash = true;
    public bool canDashDisplay = true;
    private float lastDashTime = -100f;
    private bool hasDashedInAir = false;
    private float initialY;
    private bool isJumping = false;
    private Rigidbody2D rb;
    private Vector3 initialScale;

    public Image dashImg;

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

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && Time.time - lastDashTime > dashCooldown && !hasDashedInAir)
        {
            isDashing = true;
            canDash = false;
            lastDashTime = Time.time;
            dashingDir = new Vector2(moveX, moveY);
            if (isJumping)
            {
                hasDashedInAir = true;
            }
            StartCoroutine(StopDashing());
        }

        if (isDashing)
        {
            rb.velocity = dashingDir.normalized * dashingVelocity;
        }
        else
        {
            rb.velocity = new Vector2(moveX, rb.velocity.y);
        }

        if (canDashDisplay)
            dashImg.color = Color.white;
        else
            dashImg.color = new Color(0.5f, 0.5f, 0.5f, 1); // Grey color

        // Update canDashDisplay based on cooldown, whether the player is on the ground or not, and whether the player has dashed in air
        canDashDisplay = (isJumping ? !hasDashedInAir : true) && Time.time - lastDashTime > dashCooldown;
    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        if (!isJumping)
        {
            canDash = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            hasDashedInAir = false; // Reset hasDashedInAir when the player lands on the ground
            if (Time.time - lastDashTime > dashCooldown)
            {
                canDash = true;
            }
        }
    }
}
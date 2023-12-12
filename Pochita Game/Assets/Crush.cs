using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    public Transform teleportDestination;
    public float crushingThreshold = 5.0f;

    private bool topCollision = false;
    private bool bottomCollision = false;
    public FallingRocks[] fallingRocksArray;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an object tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Check if the collision is from the top (collision normal points down)
            if (collision.contacts[0].normal.y < -0.5f)
            {
                topCollision = true;
            }
            // Check if the collision is from the bottom (collision normal points up)
            else if (collision.contacts[0].normal.y > 0.5f)
            {
                bottomCollision = true;
            }

            // Check for conditions for crushing (adjust as needed)
            if (topCollision && bottomCollision && Mathf.Abs(collision.relativeVelocity.y) > crushingThreshold)
            {
                // Get the player's renderer component
                Renderer playerRenderer = GetComponent<Renderer>();
                if (playerRenderer != null)
                {
                    playerRenderer.enabled = false;
                }

                // Disable the player's collider
                Collider2D playerCollider = GetComponent<Collider2D>();
                if (playerCollider != null)
                {
                    playerCollider.enabled = false;
                }

                // Start a coroutine to teleport the player after a delay
                StartCoroutine(TeleportPlayerAfterDelay(transform, 1f));
                foreach (FallingRocks fallingRocks in fallingRocksArray)
                {
                    if (fallingRocks != null)
                    {
                        fallingRocks.ResetPosition();
                    }
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Reset collision flags when the player is no longer colliding
        topCollision = false;
        bottomCollision = false;
    }

    private IEnumerator TeleportPlayerAfterDelay(Transform playerTransform, float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Move the player to the teleport destination
        playerTransform.position = teleportDestination.position;

        // Enable the player's renderer after the teleportation delay
        Renderer playerRenderer = playerTransform.GetComponent<Renderer>();
        if (playerRenderer != null)
        {
            playerRenderer.enabled = true;
        }

        // Enable the player's collider after the teleportation delay
        Collider2D playerCollider = playerTransform.GetComponent<Collider2D>();
        if (playerCollider != null)
        {
            playerCollider.enabled = true;
        }
    }
}

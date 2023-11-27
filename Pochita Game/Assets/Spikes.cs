using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour
{
    public Transform teleportDestination;
    public CharacterController characterController;
    public FallingRocks fallingRocks;
    public FallingRocks fallingRocks2;
    public FallingRocks fallingRocks3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable the player's renderer (make it disappear)
            Renderer playerRenderer = other.GetComponent<Renderer>();
            if (playerRenderer != null)
            {
                playerRenderer.enabled = false;
            }

            // Disable the CharacterController script
            if (characterController != null)
            {
                characterController.enabled = false;
            }

            // Start a coroutine to teleport the player after a delay
            StartCoroutine(TeleportPlayerAfterDelay(other.transform, 1f));
        }
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

        // Enable the CharacterController script after teleportation
        if (characterController != null)
        {
            characterController.enabled = true;
        }
        if (fallingRocks != null|| fallingRocks2 != null || fallingRocks3 != null)
        {
            fallingRocks.ResetPosition();
            fallingRocks2.ResetPosition();
            fallingRocks3.ResetPosition();
        }
    }
}

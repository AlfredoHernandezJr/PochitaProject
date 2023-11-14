using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Make the platform a one-way platform for the player
            Physics2D.IgnoreCollision(other, GetComponent<Collider2D>(), true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Restore normal collision behavior when the player leaves the platform
            Physics2D.IgnoreCollision(other, GetComponent<Collider2D>(), false);
        }
    }
}

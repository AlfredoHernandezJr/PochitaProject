using UnityEngine;

public class Crumble : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has a specific tag, adjust as needed
        if (collision.gameObject.CompareTag("Player"))
        {
            // Invoke the method to disable the object after 2 seconds
            Invoke("DisableCrumble", 2f);
        }
    }

    private void DisableCrumble()
    {
        // Disable the object
        gameObject.SetActive(false);

        // Invoke the method to enable the object after another 2 seconds
        Invoke("EnableCrumble", 2f);
    }

    private void EnableCrumble()
    {
        // Enable the object
        gameObject.SetActive(true);
    }
}

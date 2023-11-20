using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Proximity : MonoBehaviour
{
    public GameObject Panel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index = 0;

    public float wordSpeed;
    private bool playerIsClose;
    private Coroutine typingCoroutine;
    private Transform playerTransform; 

    void Start()
    {
        dialogueText.text = "";
        Panel.SetActive(false);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's transform.
    }

    void Update()
    {
        // Update NPC facing direction based on player's position
        if (playerIsClose)
        {
            UpdateFacingDirection();
        }
    }

    // Handle collision with the player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the Proximity trigger zone");
            playerIsClose = true;

            if (!Panel.activeInHierarchy)
            {
                Panel.SetActive(true);
                // Start the typing coroutine and store the reference.
                typingCoroutine = StartCoroutine(Typing());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the Proximity trigger zone");
            playerIsClose = false;
            RemoveText();
        }
    }

    public void RemoveText()
    {
        // Stop the typing coroutine if it's running.
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        dialogueText.text = "";
        index = 0;
        Panel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    private void UpdateFacingDirection()
    {
        // Calculate the direction from NPC to player
        Vector3 directionToPlayer = playerTransform.position - transform.position;

        // Update the sprite or rotation based on the direction
        if (directionToPlayer.x > 0)
        {
            // Player is on the right side, make the NPC face right
            transform.localScale = new Vector3(1, 1, 1); // Adjust the scale if using sprites
        }
        else if (directionToPlayer.x < 0)
        {
            // Player is on the left side, make the NPC face left
            transform.localScale = new Vector3(-1, 1, 1); // Adjust the scale if using sprites
        }
    }
}

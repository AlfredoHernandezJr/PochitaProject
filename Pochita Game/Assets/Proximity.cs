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

    void Start()
    {
        dialogueText.text = "";
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
                StartCoroutine(Typing());
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

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            RemoveText();
        }
    }
}

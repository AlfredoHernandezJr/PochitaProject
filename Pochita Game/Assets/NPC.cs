using UnityEngine;
using TMPro;
using System.Collections;

public class NPC : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;

    public TextMeshProUGUI dialogueText1;
    public TextMeshProUGUI dialogueText2;

    public string[] dialogue1;
    public string[] dialogue2;

    private int index1 = 0;
    private int index2 = 0;
    public float wordSpeed;

    private bool isPanel1Active = false;
    private bool isPanel2Active = false;

    public bool playerIsClose;

    void Start()
    {
        dialogueText1.text = "";
        dialogueText2.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isPanel1Active && !isPanel2Active && playerIsClose)
        {
            ShowPanel(panel1);
            StartCoroutine(Typing1());
            isPanel1Active = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPanel1Active)
            {
                HidePanel(panel1);
                ShowPanel(panel2);
                StartCoroutine(Typing2());
                isPanel1Active = false;
                isPanel2Active = true;
            }
            else if (isPanel2Active)
            {
                HidePanel(panel2);
                isPanel2Active = false;
            }
        }
    }

    void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
        
    }

    void HidePanel(GameObject panel)
    {
        panel.SetActive(false);
        
    }
    IEnumerator Typing1()
    {
        foreach (char letter in dialogue1[index1].ToCharArray())
        {
            dialogueText1.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    IEnumerator Typing2()
    {
        foreach (char letter in dialogue2[index2].ToCharArray())
        {
            dialogueText2.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
}

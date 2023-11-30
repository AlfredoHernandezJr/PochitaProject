using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectable : MonoBehaviour
{
    private int bread = 0;
    public List<GameObject> breadObjects; // List to store multiple bread objects
    public TextMeshProUGUI BreadCounter;

    void Start()
    {
        BreadCounter.text = "";
    }

    void Update()
    {
        BreadCounter.text = "Collectable: " + bread;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered collider");
        Debug.Log("Collided object: " + collision.gameObject);

        if (collision.gameObject.CompareTag("bread"))
        {
            Destroy(collision.gameObject); // Destroy the collided bread object
            bread++;

            // Check if there are more bread objects
            if (breadObjects.Count > 0)
            {
                // Activate the next bread object in the list
                breadObjects[0].SetActive(true);
                // Remove the activated bread object from the list
                breadObjects.RemoveAt(0);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collectable : MonoBehaviour
{
    private int bread = 0;
    public GameObject Bread;
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
            Debug.Log("entered");
            Destroy(Bread);
            bread++;
            
        }
    }

}

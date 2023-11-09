using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour
{
    private int bread = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bread"))
        {
            Destroy(collision.gameObject);
            bread++;
            Debug.Log("Collectable: " + bread);
        }
    }
}

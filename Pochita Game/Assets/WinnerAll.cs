using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinnerAll : MonoBehaviour
{
    public GameObject win;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            win.SetActive(true);
            Time.timeScale = 0;
        }
    }
    
}

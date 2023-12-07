using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growl : MonoBehaviour
{
    public AudioSource Growls;
    public GameObject SpaceGrowl;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Growls.enabled = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SpaceGrowl.SetActive(false);
        }
    }
    
}

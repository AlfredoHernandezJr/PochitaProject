using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sudoku : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject sudoku;
    public GameObject really;
    public GameObject fail;
    public Transform targetPosition;
    public int counter = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameOver.SetActive(true);
            if(counter == 0)
            {
                sudoku.SetActive(true);
            }
            if(counter == 1)
            {
                really.SetActive(true);
            }
            if(counter == 2)
            {
                fail.SetActive(true);
            }
            Time.timeScale = 0;
        }
    }

    public void MovePlayerToTarget()
    {
        GameOver.SetActive(false);
        if (counter == 0)
        {
            sudoku.SetActive(false);
        }
        if (counter == 1)
        {
            really.SetActive(false);
        }
        
        Time.timeScale = 1;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = targetPosition.position;
            counter++;
        }
    }
}

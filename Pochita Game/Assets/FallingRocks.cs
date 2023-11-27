using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRocks : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public Vector2 initialPosition;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.gravityScale = 0;
        initialPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb2D.gravityScale = 1;
        }
        
    }

    public void ResetPosition()
    {
        rb2D.velocity = Vector2.zero;
        rb2D.gravityScale = 0; 
        transform.position = initialPosition; 
    }
}

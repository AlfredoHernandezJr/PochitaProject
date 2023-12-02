using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform teleportDestination;
    public float moveSpeed = 5.0f;
    public float moveDistance = 10.0f;
    private bool moveRight = true;
    private Vector3 initialPosition;
    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = moveRight ? initialPosition + Vector3.right * moveDistance : initialPosition - Vector3.right * moveDistance;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            moveRight = !moveRight;
            Flip();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = teleportDestination.position;
        }
    }


    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }


}

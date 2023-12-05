using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBGScript : MonoBehaviour
{
    private float length, startPos;
    public float scrollSpeed; // Public variable to adjust the scroll speed

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move the background to the left at a constant speed
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, length);
        transform.position = new Vector3(startPos + newPosition, transform.position.y, transform.position.z);
    }
}

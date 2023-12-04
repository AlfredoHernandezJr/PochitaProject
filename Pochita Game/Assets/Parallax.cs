using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    private float length, startPos;
    public GameObject camera;
    public float parallaxStrength;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = (camera.transform.position.x * parallaxStrength);
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        float temp = (camera.transform.position.x * (1 - parallaxStrength));
        if (temp > startPos + length)
            startPos += length;
        else if (temp < startPos - length)
            startPos -= length;
    }
}

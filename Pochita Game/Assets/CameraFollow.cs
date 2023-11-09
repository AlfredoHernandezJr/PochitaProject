using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Reference to the player or the object you want to follow
    public float smoothSpeed = 0.125f;  // Adjust this to control the smoothness of the follow

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}

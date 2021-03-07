using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform toFollow;
    private float smoothSpeed = 0.125f;
    public float horizontalOffSet;
    public float verticalOffSet;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = toFollow.position;
        if (toFollow.gameObject.CompareTag("Player"))
        {
            desiredPosition.x += horizontalOffSet;
            desiredPosition.y += verticalOffSet;
        }
        desiredPosition.z = -1;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}

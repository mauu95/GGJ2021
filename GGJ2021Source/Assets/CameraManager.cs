using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform toFollow;
    private float smoothSpeed = 0.125f;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = toFollow.position;
        desiredPosition.z = -1;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}

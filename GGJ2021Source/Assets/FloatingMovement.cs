using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMovement : MonoBehaviour
{
    float range = 1f;
    float verticalRate = 2f;
    float horizontalRate = 1f;
    float angle = 0f;
    float angleRate = 5f;
    Vector3 originalPos;

    private void Start()
    {
        originalPos = transform.position;
    }

    private void Update()
    {
        angle += angleRate * Time.deltaTime;
        angle = angle % 360f;
        transform.position = new Vector3(originalPos.x + range * Mathf.Cos(angle * horizontalRate), originalPos.y + range * Mathf.Sin(angle * verticalRate), 0f);
    }

}

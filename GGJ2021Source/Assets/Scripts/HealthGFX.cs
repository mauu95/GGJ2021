using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthGFX : MonoBehaviour
{
    public float rotation = 2;
    public float rotationPivot = 200;

    private Transform pivot;

    private void Start()
    {
        pivot = transform.parent;
    }

    private void Update()
    {
        Vector3 axis = new Vector3(0, 0, 1);
        transform.RotateAround(pivot.position, axis, rotationPivot * Time.deltaTime);
        Vector3 rotation = new Vector3(0, 0, rotationPivot * Time.deltaTime);
        transform.Rotate(rotation);
    }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public GameObject AsteroidPrefab;
    public Transform playerPosition;
    public float VerticalRange = 10f;
    public float HorizontalRange = 20f;
    public float GenerateEveryTotSec = 2f;

    private void Start()
    {
        InvokeRepeating("Generate", 1.0f, GenerateEveryTotSec);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            Generate();
    }

    private void Generate()
    {
        float size = Random.Range(0.4f, 0.8f);
        float speed = Random.Range(30, 80);
        float rotationSpeed = Random.Range(10, 20);


        bool horizontal = true;
        if (Random.Range(0, 2) == 1)
            horizontal = false;

        Vector3 position = playerPosition.position;
        Vector2 force;
        Vector2 noise;

        if (horizontal)
        {
            noise = Vector2.down;
            force = Vector2.left;
            position += new Vector3(HorizontalRange, Random.Range(-VerticalRange,VerticalRange), 0f);
        }
        else
        {
            position += new Vector3(Random.Range(-HorizontalRange, HorizontalRange), VerticalRange, 0f);
            force = Vector2.down;
            noise = Vector2.left;
        }


        GameObject aster = Instantiate(AsteroidPrefab, position, Quaternion.identity);
        Rigidbody2D rb = aster.GetComponent<Rigidbody2D>();

        Vector3 scale = new Vector3(Random.Range(0.2f, 0.6f), Random.Range(0.1f, 0.8f), 1);
        aster.transform.localScale = scale;

        rb.AddTorque(rotationSpeed * 10);
        force *= speed * 10;
        noise *= Random.Range(-10, 10) * 10;

        rb.AddForce(force + noise);
        
    }


}

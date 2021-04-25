using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public GameObject[] AsteroidPrefabs;
    public Transform playerPosition;
    public float VerticalRange = 10f;
    public float HorizontalRange = 15;
    public float GenerateEveryTotSec = 2f;
    public bool active = false;
    public bool stop = false;

    private GameObject aster;

    private void Start()
    {
        StartCoroutine("RepeatedGenerate", 1.0f);
    }

    private IEnumerator RepeatedGenerate(float timeToStart)
    {
        float timeElapsed = 0f;
        yield return new WaitForSeconds(timeToStart);
        while (!stop)
        {
            if (!active) yield return new WaitForEndOfFrame();
            else
            {
                timeElapsed += Time.deltaTime;
                if (timeElapsed > GenerateEveryTotSec)
                {
                    Generate();
                    timeElapsed = 0f;
                }

                yield return new WaitForEndOfFrame();
            }
        }

        yield return null;
    }

    private void Generate()
    {
        if (!active)
            return;

        float speed = Random.Range(30, 80);
        float rotationSpeed = Random.Range(10, 20);
        Vector3 scale = new Vector3(Random.Range(0.2f, 0.6f), Random.Range(0.1f, 0.8f), 1);


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
            position += new Vector3(HorizontalRange, Random.Range(-VerticalRange, VerticalRange), 0f);
        }
        else
        {
            position += new Vector3(Random.Range(-HorizontalRange, HorizontalRange), VerticalRange, 0f);
            force = Vector2.down;
            noise = Vector2.left;
        }


        aster = Instantiate(AsteroidPrefabs[Random.Range(0, AsteroidPrefabs.Length)], position, Quaternion.identity);
        Rigidbody2D rb = aster.GetComponent<Rigidbody2D>();

        aster.transform.localScale = scale;

        rb.AddTorque(rotationSpeed * 10);
        force *= speed * 10;
        noise *= Random.Range(-10, 10) * 10;

        rb.AddForce(force + noise);
    }
    
}
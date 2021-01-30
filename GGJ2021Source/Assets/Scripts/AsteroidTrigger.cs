using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidTrigger : MonoBehaviour
{
    public bool enabler = true; 

    public float GenerateAsteroidEveryTotSec;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        AsteroidGenerator ag = FindObjectOfType<AsteroidGenerator>();
        if (!ag)
        {
            Debug.Log("Non hai messo l'asteroid generator!");
            return;
        }

        if (enabler)
        {
            ag.active = true;
            ag.GenerateEveryTotSec = GenerateAsteroidEveryTotSec;
        }
        else
        {
            ag.active = false;
        }

    }
}

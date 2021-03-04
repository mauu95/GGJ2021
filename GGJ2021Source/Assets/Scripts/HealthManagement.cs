using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagement : MonoBehaviour
{
    [SerializeField] public int health;

    public void AddHealth()
    {
        health++;
    }

    public void RemoveHealth()
    {
        health--;
        FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Hit", transform.position);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            RemoveHealth();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagement : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            _playerHealth.LoseLife();
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Hit", transform.position);
        }

        if (other.CompareTag("Satellite")) _playerHealth.AddLife(other.gameObject);
    }
}
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
            Debug.Log("Hit by "+other.name);
            _playerHealth.LoseLife();
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Hit", transform.position);
        }

        if (other.CompareTag("Satellite") && _playerHealth.lives<3) {
            if(other.TryGetComponent<LifeUp>(out LifeUp lifeUp)){
                _playerHealth.AddLife(lifeUp.GetActiveSat());
            }else _playerHealth.AddLife(other.gameObject);
        }
    }
}
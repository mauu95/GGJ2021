using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManagement : MonoBehaviour
{
    [SerializeField] public int health;
    private HPGFXManager HPgfx;

    private void Start()
    {
        HPgfx = GetComponentInChildren<HPGFXManager>();
        HPgfx.SetHealth(health);
    }
    public void AddHealth()
    {
        health++;
        HPgfx.SetHealth(health);
    }

    public void RemoveHealth()
    {
        health--;
        HPgfx.SetHealth(health);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Hit", transform.position);
        if (health < 0)
        {
            print("YOU LOST");
            SceneManager.LoadScene("GameOver");
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            RemoveHealth();
        }
    }
}
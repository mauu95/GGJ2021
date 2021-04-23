using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManagement : MonoBehaviour
{
    [SerializeField] public int health;
    private HPGFXManager HPgfx;
    private bool invulnerable;

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
        if (invulnerable)
            return;

        health--;
        HPgfx.SetHealth(health);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Hit", transform.position);

        if (health < 0)
            SceneManager.LoadScene("GameOver");

        StartCoroutine(ActivateInvulnerability());
    }

    private IEnumerator ActivateInvulnerability()
    {
        invulnerable = true;
        yield return new WaitForSeconds(0.5f);
        invulnerable = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            RemoveHealth();
        }
    }
}
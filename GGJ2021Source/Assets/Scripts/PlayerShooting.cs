using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject crosshairsPrefab;

    [SerializeField] private Transform firePoint;

    public float bulletSpeed = 10.0f;

    private Vector3 lookDir;
    private float rotationZ;


    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookDir = mouseWorldPoint - firePoint.transform.position;
        crosshairsPrefab.transform.position = new Vector2(mouseWorldPoint.x, mouseWorldPoint.y);


        rotationZ = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        firePoint.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (Input.GetMouseButtonDown(0)) Shoot();
    }

    private void Shoot()
    {
        if (GameManager.IsGamePaused || DialogueManager.dialogueRunning)
            return;
        float distance = lookDir.magnitude;
        Vector2 direction = lookDir / distance;
        direction.Normalize();

        InitBullet(direction, rotationZ);
    }

    private void InitBullet(Vector2 direction, float rotation)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = firePoint.position;
        b.transform.rotation = Quaternion.Euler(0, 0, rotation);
        b.GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Shooting", b.transform.position);
    }
}
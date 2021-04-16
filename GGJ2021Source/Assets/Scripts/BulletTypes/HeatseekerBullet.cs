using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatseekerBullet : Bullet
{

    private Transform player;
    [SerializeField] private float maxAngleChange = 20f;
    [SerializeField] private float speed = 5f;
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update() {
        Vector3 toPlayer = (player.position - transform.position).normalized;
        float dirAngle = Mathf.Clamp(Vector3.SignedAngle(direction,toPlayer,Vector3.forward),-maxAngleChange,maxAngleChange);
        Vector3 newDirection = Quaternion.Euler(0f,0f,dirAngle*Time.deltaTime) * direction;
        Vector3 oldDir = direction;
        Quaternion oldRotation = transform.rotation;
        Quaternion newRotation = transform.rotation * Quaternion.Euler(0f,0f,dirAngle*Time.deltaTime);
        direction = newDirection;
        transform.rotation = newRotation;
        transform.position = transform.position + direction*speed*Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if(obj.CompareTag("Player"))
            Destroy(gameObject);

    }
}

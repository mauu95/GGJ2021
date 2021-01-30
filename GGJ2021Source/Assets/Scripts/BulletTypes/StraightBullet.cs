using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBullet : Bullet
{
    [SerializeField] private float speed = 5f;
    private void Update() {
        transform.position = transform.position + direction*speed*Time.deltaTime;
    }
}

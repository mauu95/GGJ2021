﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private string[] targetTags;
    protected Vector3 origin;
    protected Vector3 direction;
    private float timeToLive =20f;
    public virtual void ShootBehaviour(Vector3 spawnPoint,Vector3 shootDir){
        origin = spawnPoint;
        direction = shootDir.normalized;
        Destroy(gameObject,timeToLive);
    }

    virtual protected void OnTriggerEnter2D(Collider2D other) {
        foreach(string t in targetTags){
            if(other.CompareTag(t)){
                Destroy(gameObject);
                return;
            }
        }
    }
}

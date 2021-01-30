using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Vector3 origin;
    protected Vector3 direction;
    private float timeToLive =20f;
    public virtual void ShootBehaviour(Vector3 spawnPoint,Vector3 shootDir){
        origin = spawnPoint;
        direction = shootDir;
        Destroy(gameObject,timeToLive);
    }
}

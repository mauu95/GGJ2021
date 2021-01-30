using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{

    [SerializeField] private GameObject bullet;

    public void Shoot(Vector3 origin, Vector3 direction){
        GameObject shotBullet = Instantiate(bullet,origin,Quaternion.Euler(0,0,0)) as GameObject;
        shotBullet.GetComponent<Bullet>().ShootBehaviour(origin,direction);
    }
}

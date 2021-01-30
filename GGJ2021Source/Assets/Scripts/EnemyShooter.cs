using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{

    [SerializeField] private GameObject bullet;

    public void Shoot(Vector3 origin, Vector3 direction){
        float bulletRot = Vector3.SignedAngle(Vector3.right,direction,Vector3.forward);
        GameObject shotBullet = Instantiate(bullet,origin,Quaternion.Euler(0,0,bulletRot)) as GameObject;
        shotBullet.GetComponent<Bullet>().ShootBehaviour(origin,direction);
    }
}

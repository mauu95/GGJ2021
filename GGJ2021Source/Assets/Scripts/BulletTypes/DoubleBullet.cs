using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBullet : Bullet
{
    [SerializeField] private GameObject shotBulletA;
    [SerializeField] private GameObject shotBulletB;
    
    [SerializeField] private float bulletAWeight = 0.5f;
    [SerializeField] private float bulletBWeight = 0.5f;

    private float threshold = 0.5f;


    private void Start() {
        bulletBWeight = bulletBWeight / (bulletAWeight + bulletBWeight);
        bulletAWeight = bulletAWeight / (bulletAWeight + bulletBWeight);
        threshold = bulletAWeight;
        //Debug.Log(threshold);
    }
    public override void ShootBehaviour(Vector3 spawnPoint, Vector3 shootDir)
    {
        base.ShootBehaviour(spawnPoint, shootDir);
        float angle = Vector3.SignedAngle(Vector3.right,direction,Vector3.forward);
        float choice = Random.Range(0f,1f);
        GameObject shotBullet ;
        if(choice <= threshold){
           shotBullet = Instantiate(shotBulletA,spawnPoint,Quaternion.Euler(0f,0f,angle));
        }
        else{
           shotBullet = Instantiate(shotBulletB,spawnPoint,Quaternion.Euler(0f,0f,angle));
        }
        shotBullet.GetComponent<Bullet>().ShootBehaviour(spawnPoint,shootDir);

    }
}

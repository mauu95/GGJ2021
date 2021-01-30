using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeWaveBullet : Bullet
{
    
    [SerializeField] private GameObject shotBullet;
    [SerializeField][Range(0f,60f)] private float coneWidth = 30f;
    // Start is called before the first frame update


    public override void ShootBehaviour(Vector3 spawnPoint, Vector3 shootDir)
    {
        base.ShootBehaviour(spawnPoint, shootDir);
        float startAngle = Vector3.SignedAngle(Vector3.right,shootDir,Vector3.forward);
        Vector3 centerDir = shootDir;
        Vector3 uppderDir = Quaternion.Euler(0,0,-coneWidth)*shootDir;
        Vector3 lowerDir = Quaternion.Euler(0,0,coneWidth)*shootDir;
        GameObject upperShot = Instantiate(shotBullet,spawnPoint,Quaternion.Euler(0,0,startAngle - coneWidth));
        GameObject centerShot = Instantiate(shotBullet,spawnPoint,Quaternion.Euler(0,0,startAngle));
        GameObject lowerShot = Instantiate(shotBullet,spawnPoint,Quaternion.Euler(0,0,startAngle + coneWidth));
        upperShot.GetComponent<Bullet>().ShootBehaviour(spawnPoint,uppderDir);
        centerShot.GetComponent<Bullet>().ShootBehaviour(spawnPoint,centerDir);
        lowerShot.GetComponent<Bullet>().ShootBehaviour(spawnPoint,lowerDir);
    }
}

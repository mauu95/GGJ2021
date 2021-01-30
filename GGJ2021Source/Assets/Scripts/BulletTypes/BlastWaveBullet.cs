using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastWaveBullet : Bullet
{
    [SerializeField] private GameObject shotBullet;
    [SerializeField][Range(0,20)]private int bulletAmount = 10;
    // Start is called before the first frame update


    public override void ShootBehaviour(Vector3 spawnPoint, Vector3 shootDir)
    {
        base.ShootBehaviour(spawnPoint, shootDir);
        Vector3 currentDir = Vector3.left;
        for(int i =0;i<bulletAmount;i++){
            currentDir = Quaternion.AngleAxis(360f * i/bulletAmount,Vector3.forward) * Vector3.left;
            GameObject shotB = Instantiate(shotBullet,spawnPoint,Quaternion.AngleAxis(360f * i/bulletAmount,Vector3.forward));
            shotB.GetComponent<Bullet>().ShootBehaviour(spawnPoint,currentDir);
        }
    }
}

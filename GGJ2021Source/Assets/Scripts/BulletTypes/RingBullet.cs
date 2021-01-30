using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingBullet : Bullet
{
    [SerializeField] private float speed = 5f;
    private float currentSpeed = 5f;
    private float speedDegradationTime = 5f;
    private float timeElapsed = 0f;

    private void Update() {
        timeElapsed += Time.deltaTime*2f;
        if(timeElapsed <= speedDegradationTime){
            float lerp = timeElapsed/ speedDegradationTime;
            currentSpeed = Mathf.Lerp(speed,0f,lerp);
        }
        else{
            float lerp = speedDegradationTime / timeElapsed;
            currentSpeed = Mathf.Lerp(-speed,0,lerp);
        }
        transform.position = transform.position + direction*currentSpeed*Time.deltaTime;
        transform.rotation = Quaternion.Euler(0,0,Random.Range(-15,15));
    }
}

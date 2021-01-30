using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveyBullet : Bullet
{
   
    [SerializeField] private float speed = 5f;
    [SerializeField][Range(0,90f)] private float maxAngleChange = 45f;
    private float shakeRate = 0.2f;
    private float timeSinceLastDirChange = 0f;
    private bool changingAngle = false;
    private void Update() {
        UpdateShakeTime();
        transform.position = transform.position + direction*speed*Time.deltaTime;
    }

    private void UpdateShakeTime(){
        timeSinceLastDirChange += Time.deltaTime;
        if(timeSinceLastDirChange > shakeRate){
            timeSinceLastDirChange = 0f;
            float angleChange = Random.Range(maxAngleChange*-1,maxAngleChange);
            StartCoroutine("ChangeDirection",angleChange);
        }
    }

    private IEnumerator ChangeDirection(float angleChange){
        if(changingAngle) yield break;
        changingAngle = true;
        float lerp = 0f;
        Vector3 newDirection = Quaternion.Euler(0,0,angleChange) * direction;
        Vector3 oldDirection = direction;
        Quaternion oldRotation = transform.rotation;
        Quaternion newRotation = transform.rotation * Quaternion.Euler(0,0,angleChange);
        while(lerp <= 1f){
            lerp += Time.deltaTime*3f;
            direction = Vector3.Lerp(oldDirection,newDirection,lerp);
            transform.rotation = Quaternion.Lerp(oldRotation,newRotation,lerp);
            yield return new WaitForEndOfFrame();
        }
        changingAngle = false;
        yield return null;
    }
}

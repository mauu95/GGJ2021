using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingRotation : MonoBehaviour
{
    private bool rotating = false;
    private void Update() {
        if(!rotating){
            StartCoroutine("RandomRotate");
        }
    }

    private IEnumerator RandomRotate(){
        if(rotating) yield break;
        rotating = true;
        Quaternion oldRot = transform.rotation;
        Quaternion nextRot = Quaternion.Euler(0,0,Random.Range(-60,60));
        float lerp = 0f;
        while(lerp <= 1f){
            lerp+= Time.deltaTime;
            transform.rotation = Quaternion.Lerp(oldRot,nextRot,lerp);
            yield return new WaitForEndOfFrame(); 
        }
        rotating = false;
        yield return null;
    }
}

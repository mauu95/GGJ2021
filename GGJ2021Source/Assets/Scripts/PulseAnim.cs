using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseAnim : MonoBehaviour
{
    [SerializeField] private float pulseAmount = 1.1f;
    private Vector3 minScale;
    private Vector3 maxScale;
    bool enlarging = true;
    float lerp = 0.5f;
    

    private void Start() {
        minScale = new Vector3(transform.localScale.x / pulseAmount,transform.localScale.y / pulseAmount,1);
        maxScale = new Vector3(transform.localScale.x * pulseAmount,transform.localScale.y * pulseAmount,1);
    }

    private void Update() {
        if(enlarging){
            lerp += Time.deltaTime;
        }
        else{
            lerp -= Time.deltaTime;
        }
        transform.localScale = Vector3.Lerp(minScale,maxScale,lerp);
        if(lerp>=1f){
            enlarging = false;
        }
        if(lerp<=0f){
            enlarging = true;
        }

    }
}

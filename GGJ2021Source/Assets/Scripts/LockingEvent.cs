using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockingEvent : MonoBehaviour
{

    private GameObject mainCamera;
    private Transform previousTarget;
    private Transform[] limiters;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        List<Transform> limitingCollider = new List<Transform>();
        for( int i =0; i<transform.childCount;i++){
            if(transform.GetChild(i).TryGetComponent<BoxCollider2D>(out BoxCollider2D coll)){
                limitingCollider.Add(transform.GetChild(i));
            }
        }
        limiters = limitingCollider.ToArray();
        fixOutOfBounds();
        setLimiters(false);
    }

    private void lockEvent(){
        previousTarget = mainCamera.GetComponent<Camera2DFollow>().target;
        mainCamera.GetComponent<Camera2DFollow>().target = mainCamera.transform;
        setLimiters(true);
    }
    public void unlockEvent(){
        setLimiters(false);
        mainCamera.GetComponent<Camera2DFollow>().target = previousTarget;
    }

    private void setLimiters(bool state){
        foreach(Transform l in limiters){
            l.gameObject.SetActive(state);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            lockEvent();
        }
    }

    private void fixOutOfBounds(){
        Transform rMost = getRightMostLimiter();
        Transform lMost = getLeftMostLimiter();
        if(transform.position.x >= rMost.position.x || transform.position.x <= lMost.position.x){
            Vector3 newPos = transform.position;
            newPos.x = lMost.position.x + GetComponent<BoxCollider2D>().size.x+0.1f;
            transform.position = newPos;
        }
    }

    private Transform getRightMostLimiter(){
        Transform rightMost = limiters[0];
        foreach(Transform l in limiters){
            if(l.position.x>rightMost.position.x){
                rightMost = l;
            } 
        }
        return rightMost;
    }
    private Transform getLeftMostLimiter(){
        Transform leftMost = limiters[0];
        foreach(Transform l in limiters){
            if(l.position.x<leftMost.position.x){
                leftMost = l;
            } 
        }
        return leftMost;
    } 
}

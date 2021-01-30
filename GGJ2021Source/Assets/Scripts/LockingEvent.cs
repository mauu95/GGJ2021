using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class LockingEvent : MonoBehaviour
{

    private Cinemachine.CinemachineVirtualCamera vmCamera;
    private Transform previousTarget;
    private Transform previousFollow;
    private Transform[] limiters;

    private Camera maincam;

    // Start is called before the first frame update
    void Start()
    {
        maincam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        vmCamera = GameObject.FindObjectOfType<Cinemachine.CinemachineVirtualCamera>();
        List<Transform> limitingCollider = new List<Transform>();
        for(int i =0; i<transform.childCount;i++){
            if(transform.GetChild(i).TryGetComponent<BoxCollider2D>(out BoxCollider2D coll)){
                limitingCollider.Add(transform.GetChild(i));
            }
        }
        limiters = limitingCollider.ToArray();
        //fixOutOfBounds();
        setLimiters(false);
    }
    private void Update() {
        CameraUtility.drawBounds(maincam);
    }

    private void lockEvent(){
        previousTarget = vmCamera.LookAt;
        previousFollow = vmCamera.Follow;
        vmCamera.Follow = transform;
        vmCamera.LookAt = transform;
        StartCoroutine("moveLimitersToEdge");
    }
    public void unlockEvent(){
        setLimiters(false);
        vmCamera.Follow = previousFollow;
        vmCamera.LookAt = previousTarget;
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
        if((lMost && rMost) && (transform.position.x >= rMost.position.x || transform.position.x <= lMost.position.x)){
            Vector3 newPos = transform.position;
            newPos.x = lMost.position.x + GetComponent<BoxCollider2D>().size.x+0.1f;
            transform.position = newPos;
        }
    }

    private IEnumerator moveLimitersToEdge(){
        yield return new WaitForSeconds(0.1f);
        Transform rMost = getRightMostLimiter();
        yield return null;
        Transform lMost = getLeftMostLimiter();
        Rect camBound = CameraUtility.getCameraBounds(maincam);
        Vector3 rBoundPos = rMost.position;
        rBoundPos.x = camBound.center.x + camBound.width/2;
        rMost.position = rBoundPos;
        Vector3 lBoundPos = lMost.position;
        lBoundPos.x = camBound.center.x - camBound.width/2;
        lMost.position = lBoundPos;
        yield return null;
        setLimiters(true);
    }

    private Transform getRightMostLimiter(){
        Transform rightMost = null;
        foreach(Transform l in limiters){
            if(!rightMost || l.position.x>rightMost.position.x){
                rightMost = l;
            } 
        }
        return rightMost;
    }
    private Transform getLeftMostLimiter(){
        Transform leftMost = null;
        foreach(Transform l in limiters){
            if(!leftMost || l.position.x<leftMost.position.x ){
                leftMost = l;
            } 
        }
        return leftMost;
    } 
}

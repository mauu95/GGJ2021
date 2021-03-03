using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class LockingEvent : MonoBehaviour
{
    private Transform[] limiters;
    private bool locked = false;
    private bool isUnlocked = false;
    private Camera maincam;

    public GameObject leftLimiter;
    public GameObject rightLimiter;

    void Start()
    {
        maincam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        List<Transform> limitingCollider = new List<Transform>();
        for(int i =0; i<transform.childCount;i++){
            if(transform.GetChild(i).TryGetComponent<BoxCollider2D>(out BoxCollider2D coll)){
                limitingCollider.Add(transform.GetChild(i));
            }
        }
        limiters = limitingCollider.ToArray();
        SetLimiters(false);
    }
    private void Update() {
        CameraUtility.drawBounds(maincam);
    }

    private void lockEvent(){
        maincam.GetComponent<CameraManager>().toFollow = transform;
        SetLimiters(true);
    }
    public void UnlockEvent(){
        isUnlocked = true;
        SetLimiters(false);
        maincam.GetComponent<CameraManager>().toFollow = FindObjectOfType<PlayerMovement>().transform;
    }

    private void SetLimiters(bool state){
        foreach(Transform l in limiters)
            l.gameObject.SetActive(state);
    }

    public void StartLock()
    {
        if (!locked && !isUnlocked)
        {
            locked = true;
            lockEvent();
        }
    }

}

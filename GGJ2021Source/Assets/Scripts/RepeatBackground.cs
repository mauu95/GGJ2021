using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Transform player;
    private Vector3 previousPos;
    private List<GameObject> backgrounds;
    private GameObject topReference;
    private GameObject bottomReference;
    private float maxX;
    private float bgwidth;
    private float bgheight;

    private void Awake() {
        backgrounds = new List<GameObject>(6);
        for(int i = 0 ; i<transform.childCount;i++){
            backgrounds.Add(transform.GetChild(i).gameObject);
        }
        topReference = transform.Find("BackgroundTop").gameObject;
        bottomReference = transform.Find("BackgroundTop").gameObject;
        bgwidth = bottomReference.GetComponent<SpriteRenderer>().bounds.size.x;
        bgheight = bottomReference.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void Update() {
        
    }

    private bool isDirectionPositive(){
        return player.transform.position.x > previousPos.x;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUp : MonoBehaviour
{
    float range = 1f;
    float verticalRate = 2f;
    float horizontalRate = 1f;
    float angle = 0f;
    float angleRate = 5f;
    Vector3 originalPos;
    
    private void Awake() {
        originalPos = transform.position;
        Transform spriteColl = transform.Find("Sprites");
        for(int i =0; i<spriteColl.childCount;i++){
            spriteColl.GetChild(i).gameObject.SetActive(false);
        }
        spriteColl.GetChild(Random.Range(0,spriteColl.childCount)).gameObject.SetActive(true);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            this.enabled = false;
        }
    }
    private void Update() {
        angle += angleRate*Time.deltaTime;
        angle = angle % 360f;
        transform.position = new Vector3(originalPos.x + range*Mathf.Cos(angle*horizontalRate),originalPos.y + range*Mathf.Sin(angle*verticalRate),0f );        
    }

    public GameObject GetActiveSat(){
        Transform spriteColl = transform.Find("Sprites");
        for(int i =0; i<spriteColl.childCount;i++){
            if(spriteColl.GetChild(i).gameObject.activeSelf){
                Transform sat = spriteColl.GetChild(i);
                spriteColl.GetChild(i).parent = null;
                return sat.gameObject;
            }
        }
        return null;
    }
}

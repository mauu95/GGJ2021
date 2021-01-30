using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatellitesHealth : MonoBehaviour
{
    private Enemy enemy;

    private float rotationSpeed = 30f;

    private float totalHealth;
    private float previousHealth;
    private float healthChunk = 0f;
    private float damageTaken = 0f;
    private GameObject satellites;

    private void Start() {
        enemy = GetComponent<Enemy>();
        totalHealth = enemy.health;
        satellites = transform.Find("Satellites").gameObject;
        previousHealth = enemy.health;
        healthChunk = totalHealth / satellites.transform.childCount;
    }

    private void Update() {
        satellites.transform.Rotate(new Vector3(0,0,rotationSpeed*Time.deltaTime),Space.Self);
        checkHealth();
    }

    private void checkHealth(){
        if(previousHealth != enemy.health){
            damageTaken += previousHealth-enemy.health;
            previousHealth = enemy.health;
        }
        if(damageTaken > healthChunk){
            for(int i =0; i<satellites.transform.childCount;i++){
                if(satellites.transform.GetChild(i).gameObject.activeSelf){
                    satellites.transform.GetChild(i).gameObject.SetActive(false);
                    damageTaken = 0;
                    break;
                }
            }
        }
    }
    
}

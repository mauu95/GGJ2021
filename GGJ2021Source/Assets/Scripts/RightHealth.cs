using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHealth : MonoBehaviour
{
    private Enemy enemy;

    private float totalHealth;
    private List<GameObject> rings;

    private void Start() {
        enemy = GetComponent<Enemy>();
        totalHealth = enemy.health;
        rings = new List<GameObject>(3);
        for(int i =0; i<transform.childCount;i++){
            if(transform.GetChild(i).name.Contains("Anello")){
                rings.Add(transform.GetChild(i).gameObject);
            }
        }
    }

    private void Update() {
        if(enemy.health/totalHealth <= 0.7f && rings.Count > 2){
            Destroy(rings[2]);
            rings.RemoveAt(2);
        }
        if(enemy.health/totalHealth <= 0.5f && rings.Count > 1){
            Destroy(rings[1]);
            rings.RemoveAt(1);
        }
        if(enemy.health/totalHealth <= 0.2f && rings.Count >0){
            Destroy(rings[0]);
            rings.RemoveAt(0);
        }
    }
}

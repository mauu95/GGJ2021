﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private bool _isStillAlive;
    public int lives{get;private set;}
    private bool invuln = false;
    private float invulntTime = 0.5f;
    private void Awake() {
        _isStillAlive = true;
        lives = transform.childCount;
    }

    public void LoseLife()
    {
        if( invuln ) return;
        _isStillAlive = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).childCount > 0)
            {
                Destroy(transform.GetChild(i).GetChild(0).gameObject);
                _isStillAlive = true;
                StartCoroutine("beInvulnerable");
                updateHealth(transform.GetChild(i));
                break;
            }
        }
        if (!_isStillAlive) SceneManager.LoadScene("GameOver");
    }
    private IEnumerator beInvulnerable(){
        invuln = true;
        float timeElapsed = 0f;
        yield return new WaitForEndOfFrame();
        while(timeElapsed <= invulntTime){
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        invuln = false;
    }

    public void AddLife(GameObject satellite)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).childCount == 0)
            {
                satellite.transform.parent = transform.GetChild(i);
                satellite.transform.localScale = Vector3.one;
                satellite.transform.localPosition = Vector3.zero;
                updateHealth();
                return;
            }
        }
    }

    private void updateHealth(Transform ignored){
        int currentLives =0;
        for(int i=0; i<transform.childCount;i++){
            if(transform.GetChild(i).childCount>0 && transform.GetChild(i)!=ignored){
                currentLives+=1;
            }
        }
        Debug.Log("Counted "+ currentLives);
        lives = currentLives;
        Debug.Log(lives);
    }
    private void updateHealth(){
        int currentLives =0;
        for(int i=0; i<transform.childCount;i++){
            if(transform.GetChild(i).childCount>0){
                currentLives+=1;
            }
        }
        Debug.Log("Counted "+ currentLives);
        lives = currentLives;
        Debug.Log(lives);
    }
}
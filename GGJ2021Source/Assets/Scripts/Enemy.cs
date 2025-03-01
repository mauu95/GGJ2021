﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField][Range(0.1f,10f)] private float attackFrequency = 0.8f;
    [SerializeField][Range(0.01f,0.9f)] private float freqVariability = 0.2f;
    [SerializeField][Range(0.1f,10f)] private float timeToPosChange = 5f;

    private float nextAttackTime = 0f;
    [Range(1f,100f)] public float health = 10f;
    [SerializeField] private LockingEvent unlockEvent;
    private Vector3[] attackPositions;
    private int currentPos;
    private bool canChangePos = false;
    private float timeFromPosChange = 0f;
    private float timeFromLastAttack = 0f;
    private bool invulnerable = false;
    private Transform player;
    private EnemyShooter shooter;
    public bool active = false;


    private void Awake() {
        nextAttackTime = attackFrequency + Random.Range(-freqVariability,freqVariability);
        List<Vector3> positions = new List<Vector3>();
        Transform posits = transform.Find("Positions");
        for(int i=0;i<posits.childCount;i++){
            positions.Add(posits.GetChild(i).position);
        }
        attackPositions = positions.ToArray();
        currentPos = 0;
        transform.position = attackPositions[currentPos];
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shooter = GetComponent<EnemyShooter>();
    }

    private void Update() {
        if(!active)return;
        movementBehaviour();
        attackBehaviour();
        GraphicsBehaviour();
    }

    private void attackBehaviour(){
        Vector3 attackOrigin = transform.position;
        Vector3 attackDirection = (player.position - transform.position).normalized;
        timeFromLastAttack += Time.deltaTime;
        if(invulnerable) return;
        if(timeFromLastAttack > nextAttackTime){
            timeFromLastAttack = 0f;
            shooter.Shoot(attackOrigin,attackDirection);
            nextAttackTime = attackFrequency + Random.Range(-freqVariability,freqVariability);
        }

    }

    private void GraphicsBehaviour(){
        if(transform.position.x > player.position.x){
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
    }

    private void movementBehaviour(){
        if(timeFromPosChange > timeToPosChange){
                canChangePos = true;
        }
        if(!canChangePos){
            timeFromPosChange += Time.deltaTime;
        }
        else{
            bool changePos = Random.value > 0.5f;
            if(changePos){
                int nextPos = Random.Range(0,attackPositions.Length);
                while(nextPos == currentPos){
                    nextPos = Random.Range(0,attackPositions.Length);
                }
                StartCoroutine("moveToNewPos",nextPos);
                timeFromPosChange = 0f;
                canChangePos = false;
            }
        }
    }

    private IEnumerator moveToNewPos(int nextPos){
        Debug.Log("Moving to "+nextPos);
        invulnerable = true;
        Vector3 oldPos = transform.position;
        Vector3 targetPos = attackPositions[nextPos];
        float lerp = 0f;
        while(lerp < 1f){
            lerp+= Time.deltaTime;
            lerp = Mathf.Min(lerp,1f);
            transform.position = Vector3.Lerp(oldPos,targetPos,lerp);
            yield return new WaitForEndOfFrame();
        }
        currentPos = nextPos;
        invulnerable = false;
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet") && !invulnerable && active){
            switch (gameObject.name)
            {
                case "Pluto":
                case "Neptune":
                case "Uranus":
                case "Saturn":
                case "Jupiter":
                case "Mars": 
                case "Mercury":
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Planets/MalePlanetHit", transform.position);
                    break;
                case "Earth":
                case "Venus":
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Planets/FemalePlanetHit", transform.position);
                    break;
               
            }
            health -= 1;
        }
        if(health <=0){
            unlockEvent.UnlockEvent();
            Destroy(gameObject);
        }
    }
}

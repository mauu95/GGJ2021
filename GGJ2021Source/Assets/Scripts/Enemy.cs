using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField][Range(0.1f,10f)] private float attackFrequency = 0.8f;
    [SerializeField][Range(0.1f,10f)] private float timeToPosChange = 5f;
    private Vector3[] attackPositions;
    private int currentPos;
    private bool canChangePos = false;
    private float timeFromPosChange = 0f;
    private float timeFromLastAttack = 0f;
    private bool invulnerable = false;
    private Transform player;
    private EnemyShooter shooter;


    private void Awake() {
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
        movementBehaviour();
        attackBehaviour();

    }

    private void attackBehaviour(){
        if(invulnerable) return;
        Vector3 attackOrigin = transform.position;
        Vector3 attackDirection = (player.position - transform.position).normalized;
        timeFromLastAttack += Time.deltaTime;
        if(timeFromLastAttack > attackFrequency){
            timeFromLastAttack = 0f;
            shooter.Shoot(attackOrigin,attackDirection);
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
}

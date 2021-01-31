using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameEvent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Launched End");
        if(other.CompareTag("Player")){
            SceneManager.LoadScene("EndGameScene");
        }
    }
}

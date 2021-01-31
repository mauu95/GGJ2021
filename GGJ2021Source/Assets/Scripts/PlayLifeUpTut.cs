using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLifeUpTut : MonoBehaviour
{
    [SerializeField] private GameObject lifeUpTutGameObject;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        lifeUpTutGameObject.SetActive(true);
    }
}

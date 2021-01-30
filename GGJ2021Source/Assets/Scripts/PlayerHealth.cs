using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool _isStillAlive;

    private void Awake() => _isStillAlive = true;
    
    public void LoseLife()
    {
        _isStillAlive = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).childCount > 0)
            {
                Destroy(transform.GetChild(i).GetChild(0).gameObject);
                _isStillAlive = true;
                break;
            }
        }

        if (!_isStillAlive)
        {
            // END GAME!
            Debug.Log("YOU DIED!");
        }
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
            }
        }
    }
}
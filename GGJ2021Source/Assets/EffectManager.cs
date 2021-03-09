using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public GameObject impactPrefab;

    public void InstantiateImpact(Vector3 position)
    {
        Instantiate(impactPrefab, position, Quaternion.identity);
    } 
}

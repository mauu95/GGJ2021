using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSec : MonoBehaviour
{
    public float seconds = 10;

    private void Start()
    {
        Destroy(gameObject,seconds);
    }
}

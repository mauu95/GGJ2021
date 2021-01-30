using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenSatellite : MonoBehaviour
{
    public float yAxisMovement;
    public float animationTime;

    private void Start()
    {
        LeanTween.moveY(gameObject, yAxisMovement, animationTime).setLoopPingPong().setEaseInSine();
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TweenPlanet : MonoBehaviour
{
    [SerializeField] private Vector3 scaleFactor;
    [SerializeField] private float tweenTime;
    [SerializeField] private LeanTweenType easeType;

    private void Start()
    {
        LeanTween.scale(gameObject, scaleFactor, tweenTime).setLoopPingPong().setEase(easeType);
    }
}
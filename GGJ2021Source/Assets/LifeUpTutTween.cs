using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeUpTutTween : MonoBehaviour
{
    public int tweenTime;
    public LeanTweenType easeType;
    
    private void Start() => Tween();

    private void Tween()
    {
        LeanTween.scale(gameObject, Vector3.zero, tweenTime).setEase(easeType);
    }
}
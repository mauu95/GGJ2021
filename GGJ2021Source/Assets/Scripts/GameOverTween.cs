using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTween : MonoBehaviour
{
    private void Start() => Tween();

    private void Tween()
    {
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, Vector3.zero, 5).setEaseInSine();
    }
}
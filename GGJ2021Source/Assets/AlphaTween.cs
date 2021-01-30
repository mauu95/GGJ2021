﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaTween : MonoBehaviour
{
    private void Start() => Tween();

    private void Tween()
    {
        Image image = GetComponent<Image>();

        LeanTween.value(gameObject, 1, 0, 5).setOnUpdate((float value) =>
        {
            Color c = image.color;
            c.a = value;
            image.color = c;
        });
    }
}
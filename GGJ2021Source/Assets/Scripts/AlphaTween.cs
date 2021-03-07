using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaTween : MonoBehaviour
{
    public int tweenTime = 5;
    public GameObject menu;
    private void Start() => Tween();

    private void Tween()
    {
        Image image = GetComponent<Image>();

        LeanTween.value(gameObject, 1, 0, tweenTime).setOnUpdate(value =>
        {
            Color c = image.color;
            c.a = value;
            image.color = c;
        });
    }

    private void FixedUpdate()
    {
        Image image = GetComponent<Image>();
        if (image.color.a == 0)
            menu.SetActive(true);
    }
}
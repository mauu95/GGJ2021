using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaTween : MonoBehaviour
{
    public int tweenTime = 5;
    public GameObject menu;
    private Image image;
    private void Start() {
        Tween();
        image = GetComponent<Image>();
    } 

    private void Tween()
    {
        LeanTween.value(gameObject, 1, 0, tweenTime).setOnUpdate(value =>
        {
            Color c = image.color;
            c.a = value;
            image.color = c;
        });
    }

    private void FixedUpdate()
    {
        if (image.color.a == 0)
        {
            FindObjectOfType<GameManager>().CursorOn();
            menu.SetActive(true);
        }

    }
}
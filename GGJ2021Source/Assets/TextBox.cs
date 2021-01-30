using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    #region Singleton
    public static TextBox instance;

    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }

    #endregion

    public Sprite[] characterSprites;
    public TextMeshProUGUI text;
    public Image charIMG;

    public void SetText(string text)
    {
        this.text.text = text;
    }

    public void SetCharIMG(int n)
    {
        if (n < 0 || n > characterSprites.Length)
            charIMG.sprite = null;
        charIMG.sprite = characterSprites[n];
    }
}

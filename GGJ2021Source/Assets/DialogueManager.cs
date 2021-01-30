using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private TextBox tb;
    Sentence s1 = new Sentence("Sole", "aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa");

    private void Start()
    {
        tb = TextBox.instance;
        Play(s1);
    }

    public void Play(Sentence sentence)
    {
        tb.SetCharIMG(sentence.GetPlanetID());
        tb.SetText(sentence.GetText());
    }
}

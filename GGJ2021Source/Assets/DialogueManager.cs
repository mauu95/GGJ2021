using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    #region Singleton
    public static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }

    #endregion


    private TextBox tb;

    Sentence[] dialogue1 =
    {
    new Sentence("plutone", "Hello planet! Are you lost?"),
    new Sentence("found", "Well, actually my name is Found. My galaxy was destroyed by a black hole"),
    new Sentence("found", "but I managed to escape and now Im looking for a new system to call my home"),
    new Sentence("plutone", "You could stay here! I mean, not all planets will be happy,"),
    new Sentence("plutone", "they don’t even consider me as one of them. Anyway, if you"),
    new Sentence("plutone", "convince the Sun I bet he’ll give you a place in our orbit."),
    new Sentence("found", "Convince?"),
    new Sentence("plutone", "You come from the stars. Use their power to show the others"),
    new Sentence("plutone", "you’re worthy of our System. And be careful: your satellites"),
    new Sentence("plutone", "are fundamental for your balance in the universe, without"),
    new Sentence("plutone", "them you are nothing. If you don’t want to lose them you"),
    new Sentence("plutone", "should be careful and avoid getting hit."),
    new Sentence("plutone", "Now good luck, Found!"),
    new Sentence("None", "WASD = move, SPACE = jump, MOUSE SX = shoot")
    
    };

    Sentence[] dialogue2 =
    {
    new Sentence("nettuno", "Who are you? How dare you disturb me?"),
    new Sentence("found", "Hello, I'm Found, I come from another galaxy."),
    new Sentence("found", "I just need a place to stay."),
    new Sentence("nettuno", "We'll see about that.")
    };

    public void Play(Sentence sentence)
    {
        if (!tb)
            tb = TextBox.instance;

        if (!tb.isActiveAndEnabled)
            tb.gameObject.SetActive(true);

        tb.SetCharIMG(sentence.GetPlanetID());
        tb.SetText(sentence.GetText());
    }

    private IEnumerator Deactivate(float n) {
        yield return new WaitForSeconds(n);
        tb.gameObject.SetActive(false);
    }

    public void Play(string planet, string text)
    {
        Play(new Sentence(planet, text));
    }

    public void PlayDialogue(int n){
        Sentence[] dialogue = dialogue1;
        StartCoroutine(PlayDialogueCoroutine(dialogue));
    }

    public IEnumerator PlayDialogueCoroutine(Sentence[] dialogue)
    {
        foreach(Sentence s in dialogue)
        {
            Play(s);
            yield return StartCoroutine(WaitForKeyDown(KeyCode.Return));
            yield return new WaitForSeconds(0.01f);
        }

        tb.gameObject.SetActive(false);
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyUp(keyCode))
            yield return null;
    }

}

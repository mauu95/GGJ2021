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
        new Sentence("plutone", "Hello planet! Are you lost? "),
        new Sentence("found", "a bello"),
        new Sentence("plutone", "babbalucco")
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

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

    Sentence[] dialogue3 =
    {
    new Sentence("urano", "So it's true, we have a visitor in our System. I heard you have"),
    new Sentence("urano", "already met some of my fellow planets. Let me guess, Neptune didn't let"),
    new Sentence("urano", "you move along without putting up a fight."),
    new Sentence("found", "I beat him. What's his problem?"),
    new Sentence("urano", "Oh, he has quite a cold heart. But I'm proud to admit I'm the coldest."),
    new Sentence("found", "You are?"),
    new Sentence("urano", "I must be. How else would I survive all the jokes the other planets"),
    new Sentence("urano", "tell each other about me? But now I must let you go."),
    new Sentence("urano", "You still have a hard journey ahead of you.")
    };

    Sentence[] dialogue4 =
    {
    new Sentence("saturno", "I can't believe Uranus let you through. Not that you will be able to"),
    new Sentence("saturno", "take down my majestic rings easily anyway."),
    new Sentence("saturno", "Come, let's see if your core is strong enough to beat me.")
    };

    Sentence[] dialogue5 =
    {
    new Sentence("giove", "I see you managed to beat Saturn. Now listen to me: I'm the big boss"),
    new Sentence("giove", "on this side of the Asteroid Belt, so let me give you a piece of advice."),
    new Sentence("giove", "The Sun will never accept you in our System, and neither will most of"),
    new Sentence("giove", "the planets you'll meet from now on. Still, if you don't cross the Belt,"),
    new Sentence("giove", "maybe there's still a chance you can go back and find another galaxy."),
    new Sentence("found", "But I like it here, some planets have been nice to me and I'm too tired"),
    new Sentence("found", "to go back into deep space."),
    new Sentence("giove", "Then I will have to stop you. Come, my moons, it's time to fight.")
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

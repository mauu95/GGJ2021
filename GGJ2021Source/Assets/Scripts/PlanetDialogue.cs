using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDialogue : MonoBehaviour
{
    private bool interacted = false;
    public int dialogueNumber;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        LaunchDialogue();
    }
    protected virtual void LaunchDialogue(){
        if (interacted)
        {
            return;
        }
        else
        {
            DialogueManager.instance.PlayDialogue(dialogueNumber);
            interacted = true;
        }
    }
}

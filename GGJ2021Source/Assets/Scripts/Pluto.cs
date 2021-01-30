using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pluto : MonoBehaviour
{
    private bool interacted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (interacted)
        {
            return;
        }
        else
        {
            DialogueManager.instance.PlayDialogue(1);
            interacted = true;
        }
    }
}

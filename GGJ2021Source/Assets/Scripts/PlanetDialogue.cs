using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDialogue : MonoBehaviour
{
    private bool interacted = false;
    public int dialogueNumber;
    [SerializeField] private LockingEvent unlockEvent;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;
        LaunchDialogue();
    }
    protected virtual void DialogueEnd(){
        if(!unlockEvent) return;
        else{
            unlockEvent.UnlockEvent();
        }
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
        StartCoroutine("WaitForDialogueEnd");
    }
    protected IEnumerator WaitForDialogueEnd(){
        yield return new WaitForSeconds(0.2f);
        while(DialogueManager.dialogueRunning){
            yield return new WaitForEndOfFrame();
        }
        DialogueEnd();
        yield return null;
    }
}

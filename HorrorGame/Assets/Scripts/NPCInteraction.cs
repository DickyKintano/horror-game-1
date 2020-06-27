using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : Interactable
{
    [SerializeField] NPC npc;
    public Dialogue dialogue;

    public override void Interact()
    {
        base.Interact();
        talk();
    }

    public void talk()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        hasInteracted = false;
    }
}

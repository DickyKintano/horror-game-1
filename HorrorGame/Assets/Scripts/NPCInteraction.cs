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
        Talk();
    }

    public void Talk()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, true);
        hasInteracted = false;
    }
}

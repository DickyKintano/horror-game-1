using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointInteraction : Interactable
{
    [SerializeField] private SaveUI save;

    public override void Interact()
    {
        base.Interact();
        Save();
    }

    public void Save()
    {
        save.ShowUI();
        hasInteracted = false;
    }
}

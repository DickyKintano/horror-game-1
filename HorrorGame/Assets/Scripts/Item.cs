﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    //"new" keyword means its overwritting the old definition of name
    [Tooltip("The name of the item")]
    new public string name = "New Item";
    [Tooltip("The icon of the item")]
    public Sprite icon = null;

    public virtual void Use()
    {
        //use the item

        Debug.Log("Using the item");
    }
}

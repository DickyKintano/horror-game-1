﻿using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    Item item;

    public Image icon;
    [SerializeField] private Button useButton;
    [SerializeField] private Button discardButton;

    public void AddItem(Item newItem)
    {
        item = newItem;

        Debug.Log("new item icon: " + item.icon);

        icon.sprite = item.icon;
        icon.enabled = true;

        this.GetComponent<Button>().interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

        this.GetComponent<Button>().interactable = false;
    }

    public void onClickItem()
    {
        useButton.interactable = true;
        discardButton.interactable = true;
    }

    public void onUseButton()
    {
        //use the item

        useButton.interactable = false;
        discardButton.interactable = false;
    }

    public void onDiscardButton()
    {
        //need to fill the gap where the item was discarded
        //discard the item
        Inventory.instance.RemoveItem(item);
        useButton.interactable = false;
        discardButton.interactable = false;
    }
}

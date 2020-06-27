using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private Button useButton;
    [SerializeField] private Button discardButton;

    private Item item;
    public Image icon;

    public void AddItem(Item newItem)
    {
        item = newItem;

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
        //discard the item
        Inventory.instance.RemoveItem(item);
        useButton.interactable = false;
        discardButton.interactable = false;
    }
}

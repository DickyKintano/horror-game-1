using UnityEngine;

public class ItemPickup : Interactable
{

    [SerializeField] Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    public void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        //add item to inventory
        bool wasPicked = Inventory.instance.AddItem(item);
        if (wasPicked)
        {
            Destroy(gameObject);
        }
    }
}

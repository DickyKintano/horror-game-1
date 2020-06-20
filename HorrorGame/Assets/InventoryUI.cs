using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public Transform itemsParent;
    Inventory inventory;
    InventoryItem[] slots;


    /** Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.OnItemChangeCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventoryItem>();
    }
    **/

    public void init()
    {
        inventory = Inventory.instance;
        inventory.OnItemChangeCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventoryItem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            } else
            {
                slots[i].ClearSlot();
            }
        }
    }
}

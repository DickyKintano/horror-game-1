using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject inventory;

    private void Start()
    {
        inventory.GetComponent<InventoryUI>().init();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            OpenInvent();
        }

    }

    public void OpenInvent()
    {
        if (!inventory.activeInHierarchy)
        {
            inventory.SetActive(true);
        } else 
        {
            inventory.SetActive(false);
        }
    }
}

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
            Time.timeScale = 0;
            inventory.SetActive(true);
        } else 
        {
            Time.timeScale = 1;
            inventory.SetActive(false);
        }
    }
}

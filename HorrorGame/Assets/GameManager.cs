using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    //[SerializeField] private Button continueButton;

    private void Start()
    {
        inventory.GetComponent<InventoryUI>().init();

        // enable continue button if save file exist
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

using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private Transform player;

    #region Inventory

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
    #endregion

    #region Save & Load

    public void SaveGame()
    {
        SaveSystem.SaveGame(player);
    }

    public void LoadGame()
    {
        SaveSystem.LoadGame();
    }

    #endregion

}

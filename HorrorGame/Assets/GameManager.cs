using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Transform player;

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

        if (Input.GetButtonDown("PauseMenu"))
        {
            OpenPauseMenu();
        }

    }

    #region Inventory Menu

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

    #region Pause Menu

    public void OpenPauseMenu()
    {
        if (pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        } else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    #endregion

    #region Save & Load System

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

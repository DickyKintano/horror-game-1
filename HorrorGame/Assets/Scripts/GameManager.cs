using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionMenu;
    [SerializeField] private Transform player;

    private bool isPaused = false;

    public TMP_Dropdown drop;

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
            GamePause();
        }

    }

    private void TestFunction()
    {
        int currval = drop.value;
        drop.value = 1;
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

    public void GamePause()
    {
        if (isPaused)
        {
            pauseMenu.SetActive(false);
            optionMenu.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        } else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    #endregion

    #region Save & Load System

    public void SaveGame(int slotNum)
    {
        SaveSystem.SaveGame(player, slotNum);
    }

    public void LoadGame(int slotNum)
    {
        SaveSystem.LoadGame(slotNum);
    }

    #endregion

}

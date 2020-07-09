using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveUI : MonoBehaviour
{
    [SerializeField] private GameObject overwriteText;
    [SerializeField] private GameObject saveText;
    [SerializeField] private GameObject saveUI;

    private int currSlot;

    public GameManager gameManager;
    public GameObject confirmationWIndow;


    // Start is called before the first frame update
    void Start()
    {
        currSlot = 3;
    }

    //awake called before start used to set player preferences
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("SSlot0"))
        {
            PlayerPrefs.SetInt("SSlot0", 0);
        }

        if (!PlayerPrefs.HasKey("SSlot1"))
        {
            PlayerPrefs.SetInt("SSlot1", 0);
        }

        if (!PlayerPrefs.HasKey("SSlot2"))
        {
            PlayerPrefs.SetInt("SSlot2", 0);
        }
    }

    public void ShowUI()
    {
        saveUI.SetActive(true);
    }

    public void SaveSlot1()
    {
        currSlot = 0;
        Debug.Log("using save slot #" + currSlot);
        confirmationWIndow.SetActive(true);
        if (PlayerPrefs.GetInt("SSlot0") == 1)
        {
            overwriteText.SetActive(true);
        } else
        {
            saveText.SetActive(true);
        }
    }

    public void SaveSlot2()
    {
        currSlot = 1;
        Debug.Log("using save slot #" + currSlot);
        confirmationWIndow.SetActive(true);
        if (PlayerPrefs.GetInt("SSlot1") == 1)
        {
            overwriteText.SetActive(true);
        }
        else
        {
            saveText.SetActive(true);
        }
    }

    public void SaveSlot3()
    {
        currSlot = 2;
        Debug.Log("using save slot #" + currSlot);
        confirmationWIndow.SetActive(true);
        if (PlayerPrefs.GetInt("SSlot2") == 1)
        {
            overwriteText.SetActive(true);
        }
        else
        {
            saveText.SetActive(true);
        }
    }

    public void ConfirmSave()
    {
        gameManager.SaveGame(currSlot);
        PlayerPrefs.SetInt("SSlot" + currSlot, 1);

        //reset the window text and close it
        saveText.SetActive(false);
        overwriteText.SetActive(false);
        confirmationWIndow.SetActive(false);

        //update the save information to the UI
        UpdateUI(currSlot);
    }

    public void CancelSave()
    {
        saveText.SetActive(false);
        overwriteText.SetActive(false);
        confirmationWIndow.SetActive(false);
    }

    public void BackButton()
    {
        Debug.Log("back button pressed");
        saveUI.SetActive(false);
    }

    //update the UI to display save information
    public void UpdateUI(int saveSlot)
    {
        //show save information in the UI
        //e.g. save time, date, player position
    }
}

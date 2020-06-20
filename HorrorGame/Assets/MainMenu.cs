using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private Button continueButton;

    private void Start()
    {
        //check if save file exist
        if (File.Exists(Application.persistentDataPath + "/SAVEDATA.sav")) {
            continueButton.interactable = true;
        } else
        {
            continueButton.interactable = false;
            Debug.Log("no save file found");
        }
    }

    public void NewGame()
    {
        //start a new game
        //load the next scene queued up in the manager
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ContinueGame()
    {
        //load a save file
        
    }

    public void ShowOptions()
    {
        //display option panel
        optionPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void QuitGame()
    {
        //close the game
        Application.Quit();
    }


}

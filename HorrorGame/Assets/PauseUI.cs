using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject optionUI;

    public void ResumeButton()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void OptionButton()
    {
        optionUI.SetActive(true);
    }

    public void TitleButton()
    {
        //load the title scene
        SceneManager.LoadScene(0);
    }
}

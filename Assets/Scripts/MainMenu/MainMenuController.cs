using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject aboutUI;
    [SerializeField] private GameObject creditUI;
    private int currentUI = 0;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentUI == 0)
            {
                QuitGame();
            }
            else if(currentUI == 1)
            {
                QuitAbout();
            }
            else
            {
                QuitCredit();
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Openning");
    }

    public void ShowAbout()
    {
        mainUI.SetActive(false);
        aboutUI.SetActive(true);
        currentUI = 1;
    }

    public void QuitAbout()
    {
        mainUI.SetActive(true);
        aboutUI.SetActive(false);
        currentUI = 0;
    }

    public void ShowSetting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void ShowCredit()
    {
        mainUI.SetActive(false);
        creditUI.SetActive(true);
        currentUI = 2;
    }

    public void QuitCredit()
    {
        mainUI.SetActive(true);
        creditUI.SetActive(false);
        currentUI = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
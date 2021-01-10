using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainUI = null;
    [SerializeField] private GameObject aboutUI = null;
    [SerializeField] private GameObject creditUI = null;
    [SerializeField] private GameObject quitUI = null;
    [SerializeField] private new AudioSource audio = null;
    private int currentUI;

    private void Start()
    {
        mainUI.SetActive(true);
        aboutUI.SetActive(false);
        creditUI.SetActive(false);
        quitUI.SetActive(false);
        currentUI = 0;
        audio.volume = PlayerPrefs.GetFloat("audioVolume", 1);
        QualitySettings.vSyncCount = PlayerPrefs.GetInt("isVsyncMode", 0);
        Application.targetFrameRate = PlayerPrefs.GetInt("currentFps", 60);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentUI == 0)
            {
                ShowQuit();
            }
            else if(currentUI == 1)
            {
                QuitAbout();
            }
            else if(currentUI == 2)
            {
                QuitCredit();
            }
            else if(currentUI == 3)
            {
                HideQuit();
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

    public void ShowQuit()
    {
        quitUI.SetActive(true);
        currentUI = 3;
    }

    public void HideQuit()
    {
        quitUI.SetActive(false);
        currentUI = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2Controller : MonoBehaviour
{
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject tipsUI;
    [SerializeField] private AudioSource bgm;
    private bool isUI;
    private bool gameIsPause;

    private void Start()
    {
        SceneController.currentStage = 2;
        Time.timeScale = 0f;
        gameIsPause = false;
        isUI = true;
        tipsUI.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isUI == false)
            {
                if (gameIsPause == false)
                {
                    Pause();
                }
                else
                {
                    Resume();
                }
            }
        }
    }

    public void GotIt()
    {
        isUI = false;
        tipsUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        gameIsPause = true;
        bgm.Pause();
        gameUI.SetActive(false);
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        gameIsPause = false;
        bgm.Play();
        gameUI.SetActive(true);
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
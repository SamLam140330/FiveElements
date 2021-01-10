using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage1Controller : MonoBehaviour
{
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject tipsUI;
    [SerializeField] private AudioSource bgm;
    [SerializeField] private Text timeTxt;
    [SerializeField] private GameObject[] boxImage;
    [SerializeField] private GameObject[] emptyImage;
    [SerializeField] private GameObject WinTxt;
    public int completeBox;
    private bool isUI;
    private bool gameIsPause;
    private float timeLeft;

    private void Start()
    {
        Time.timeScale = 0f;
        completeBox = 0;
        SceneController.currentStage = 1;
        timeLeft = 180;
        gameIsPause = false;
        isUI = true;
        tipsUI.SetActive(true);
    }

    private void Update()
    {
        if(completeBox < 5)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(isUI == false)
                {
                    if(gameIsPause == false)
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
        TimeCount();
        TimeEnd();
    }

    public void GotIt()
    {
        isUI = false;
        tipsUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void CheckWin()
    {
        if(completeBox == 1)
        {
            emptyImage[0].SetActive(false);
            boxImage[0].SetActive(true);
        }
        if(completeBox == 2)
        {
            emptyImage[1].SetActive(false);
            boxImage[1].SetActive(true);
        }
        if(completeBox == 3)
        {
            emptyImage[2].SetActive(false);
            boxImage[2].SetActive(true);
        }
        if(completeBox == 4)
        {
            emptyImage[3].SetActive(false);
            boxImage[3].SetActive(true);
        }
        if(completeBox == 5)
        {
            emptyImage[4].SetActive(false);
            boxImage[4].SetActive(true);
            WinTxt.SetActive(true);
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Stage2");
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
        SceneManager.LoadScene("Stage1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void TimeCount()
    {
        if(completeBox < 5)
        {
            timeLeft -= Time.deltaTime;
            timeTxt.text = "Time Remain: " + timeLeft + "s";
            if(timeLeft <= 60)
            {
                timeTxt.color = Color.yellow;
            }
            if(timeLeft <= 30)
            {
                timeTxt.color = Color.red;
            }
        }
    }

    private void TimeEnd()
    {
        if(timeLeft <= 0)
        {
            SceneManager.LoadScene("Ending2");
        }
    }
}
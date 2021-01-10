using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage3Controller : MonoBehaviour
{
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject tipsUI;
    [SerializeField] private GameObject wrongUI;
    [SerializeField] private AudioSource bgm;
    [SerializeField] private Text timeTxt;
    [SerializeField] private GameObject correctTxt;
    [SerializeField] private GameObject stopBtm;
    [SerializeField] private GameObject WinTxt;
    [SerializeField] private GameObject[] playerAns;
    [SerializeField] private GameObject[] answerUI;
    [SerializeField] private GameObject[] allDoor;
    [SerializeField] private GameObject[] questionUI;
    [SerializeField] private GameObject[] emptyImage;
    [SerializeField] private GameObject[] elementImage;
    private bool isUI;
    private bool isUITip;
    private bool gameIsPause;
    private float timeLeft;
    public int finishedQuestion;
    public int finishedQuestionImage;

    private void Start()
    {
        Time.timeScale = 0f;
        finishedQuestion = 0;
        timeLeft = 300;
        SceneController.currentStage = 3;
        gameIsPause = false;
        isUI = false;
        isUITip = true;
        tipsUI.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isUI == false && isUITip == false)
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
            else
            {
                TurnOffQuestion();
                Cancel();
            }
        }
        TimeCount();
        TimeEnd();
        DisplayUI();
        ShowQuestion();
    }

    public void GotIt()
    {
        isUITip = false;
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

    public void Restart()
    {
        SceneManager.LoadScene("Stage3");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void TimeCount()
    {//Win Cordition
        timeLeft -= Time.deltaTime;
        timeTxt.text = "Time Remain: " + timeLeft + "s";
        if(timeLeft <= 100)
        {
            timeTxt.color = Color.yellow;
        }
        if(timeLeft <= 40)
        {
            timeTxt.color = Color.red;
        }
    }

    private void DisplayUI()
    {
        if(PlayerController.currentUI == 1)
        {
            isUI = true;
            answerUI[0].SetActive(true);
            stopBtm.SetActive(false);
        }
        else if(PlayerController.currentUI == 2)
        {
            isUI = true;
            answerUI[1].SetActive(true);
            stopBtm.SetActive(false);
        }
        else if(PlayerController.currentUI == 3)
        {
            isUI = true;
            answerUI[2].SetActive(true);
            stopBtm.SetActive(false);
        }
        else if(PlayerController.currentUI == 4)
        {
            isUI = true;
            answerUI[3].SetActive(true);
            stopBtm.SetActive(false);
        }
        else if(PlayerController.currentUI == 5)
        {
            isUI = true;
            answerUI[4].SetActive(true);
            stopBtm.SetActive(false);
        }
    }

    public void CheckAnswer()
    {
        if(playerAns[0].GetComponent<Text>().text == "72474" && PlayerController.currentUI == 1)
        {
            allDoor[0].SetActive(false);
            PlayerController.currentUI = 0;
            answerUI[0].SetActive(false);
            StartCoroutine(Correct());
        }
        else if(playerAns[1].GetComponent<Text>().text == "1" && PlayerController.currentUI == 2)
        {
            allDoor[1].SetActive(false);
            PlayerController.currentUI = 0;
            answerUI[1].SetActive(false);
            StartCoroutine(Correct());
        }
        else if(playerAns[2].GetComponent<Text>().text == "3467" && PlayerController.currentUI == 3)
        {
            allDoor[2].SetActive(false);
            PlayerController.currentUI = 0;
            answerUI[2].SetActive(false);
            StartCoroutine(Correct());
        }
        else if(playerAns[3].GetComponent<Text>().text == "00" && PlayerController.currentUI == 4)
        {
            allDoor[3].SetActive(false);
            PlayerController.currentUI = 0;
            answerUI[3].SetActive(false);
            StartCoroutine(Correct());
        }
        else if(playerAns[4].GetComponent<Text>().text == "6" && PlayerController.currentUI == 5)
        {
            allDoor[4].SetActive(false);
            PlayerController.currentUI = 0;
            answerUI[4].SetActive(false);
            StartCoroutine(Correct());
        }
        else
        {
            StartCoroutine(Wrong());
        }
    }

    private void ShowQuestion()
    {
        if(PlayerController.currentQuestion == 1)
        {
            isUI = true;
            questionUI[0].SetActive(true);
            stopBtm.SetActive(false);
        }
        else if(PlayerController.currentQuestion == 2)
        {
            isUI = true;
            questionUI[1].SetActive(true);
            stopBtm.SetActive(false);
        }
        else if(PlayerController.currentQuestion == 3)
        {
            isUI = true;
            questionUI[2].SetActive(true);
            stopBtm.SetActive(false);
        }
        else if(PlayerController.currentQuestion == 4)
        {
            isUI = true;
            questionUI[3].SetActive(true);
            stopBtm.SetActive(false);
        }
        else if(PlayerController.currentQuestion == 5)
        {
            isUI = true;
            questionUI[4].SetActive(true);
            stopBtm.SetActive(false);
        }
    }

    public void GetElement()
    {
        if(finishedQuestionImage == 1)
        {
            elementImage[0].SetActive(true);
            emptyImage[0].SetActive(false);
        }
        if(finishedQuestionImage == 2)
        {
            elementImage[1].SetActive(true);
            emptyImage[1].SetActive(false);
        }
        if (finishedQuestionImage == 3)
        {
            elementImage[2].SetActive(true);
            emptyImage[2].SetActive(false);
        }
        if (finishedQuestionImage == 4)
        {
            elementImage[3].SetActive(true);
            emptyImage[3].SetActive(false);
        }
        if (finishedQuestionImage == 5)
        {
            elementImage[4].SetActive(true);
            emptyImage[4].SetActive(false);
        }
    }

    public void CheckWin()
    {
        if(finishedQuestion == 5)
        {
            WinTxt.SetActive(true);
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Ending3");
    }

    public void TurnOffQuestion()
    {
        for(int i = 0; i < questionUI.Length; i++)
        {
            questionUI[i].SetActive(false);
        }
        PlayerController.currentQuestion = 0;
        isUI = false;
        stopBtm.SetActive(true);
    }

    public void Cancel()
    {
        for(int i = 0; i < answerUI.Length; i++)
        {
            answerUI[i].SetActive(false);
        }
        PlayerController.currentUI = 0;
        isUI = false;
        stopBtm.SetActive(true);
    }

    private void TimeEnd()
    {
        if(timeLeft <= 0)
        {
            SceneManager.LoadScene("Ending2");
        }
    }

    IEnumerator Wrong()
    {
        for(int i = 0; i <= 2; i++)
        {
            wrongUI.SetActive(true);
            yield return new WaitForSeconds(1.2f);
            wrongUI.SetActive(false);
            yield return new WaitForSeconds(0.6f);
        }
    }

    IEnumerator Correct()
    {
        for(int i = 0; i <= 2; i++)
        {
            correctTxt.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            correctTxt.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
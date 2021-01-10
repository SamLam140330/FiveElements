using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage3Controller : MonoBehaviour
{
    [SerializeField] private GameObject gameUI = null;
    [SerializeField] private GameObject pauseUI = null;
    [SerializeField] private GameObject tipsUI = null;
    [SerializeField] private GameObject wrongUI = null;
    [SerializeField] private Text timeTxt = null;
    [SerializeField] private GameObject correctTxt = null;
    [SerializeField] private GameObject stopBtm = null;
    [SerializeField] private GameObject WinTxt = null;
    [SerializeField] private new AudioSource audio = null;
    [SerializeField] private AudioSource sfx1 = null;
    [SerializeField] private AudioSource sfx2 = null;
    public AudioSource sfx3 = null;
    [SerializeField] private GameObject[] playerAns = null;
    [SerializeField] private GameObject[] answerUI = null;
    [SerializeField] private GameObject[] allDoor = null;
    [SerializeField] private GameObject[] questionUI = null;
    [SerializeField] private GameObject[] emptyImage = null;
    [SerializeField] private Sprite[] images = null;
    [HideInInspector] public bool checkWon;
    [HideInInspector] public int gotElement;
    [HideInInspector] public int currentElement;
    [HideInInspector] public string finishedQuestion;
    private PlayerController playerController;
    private bool isUI;
    private bool isUITip;
    private bool gameIsPause;
    private float timeLeft;
    private bool isWrong;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Time.timeScale = 0f;
        gotElement = 0;
        currentElement = 0;
        timeLeft = 300f;
        SceneController.currentStage = "Stage3";
        gameIsPause = false;
        isUI = false;
        isUITip = true;
        isWrong = false;
        checkWon = false;
        tipsUI.SetActive(true);
        audio.volume = PlayerPrefs.GetFloat("audioVolume", 1f);
        sfx1.volume = PlayerPrefs.GetFloat("sfxVolume", 1f);
        sfx2.volume = PlayerPrefs.GetFloat("sfxVolume", 1f);
        sfx3.volume = PlayerPrefs.GetFloat("sfxVolume", 1f);
    }

    private void Update()
    {
        CheckESC();
        CheckTime();
    }

    private void CheckESC()
    {
        if(checkWon == false)
        {
            if(Input.GetKeyDown(KeyCode.Escape) && isWrong == false)
            {
                if(isUI == false && isUITip == false)
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
                else
                {
                    TurnOffQuestion();
                    Cancel();
                }
            }
        }
    }

    private void CheckTime()
    {
        if(checkWon == false)
        {
            timeLeft -= Time.deltaTime;
            timeTxt.text = "剩餘時間: " + (int)timeLeft + "s";
            if(timeLeft <= 150f)
            {
                timeTxt.color = Color.yellow;
            }
            if(timeLeft <= 75f)
            {
                timeTxt.color = Color.red;
            }
            if(timeLeft <= 0f)
            {
                SceneManager.LoadScene("Ending2");
            }
        }
    }

    public void DisplayUI()
    {
        if(PlayerController.currentUI == 1)
        {
            sfx3.Stop();
            playerController.playerAnimator.SetBool("IsRunning", false);
            isUI = true;
            answerUI[0].SetActive(true);
            stopBtm.SetActive(false);
        }
        else if(PlayerController.currentUI == 2)
        {
            sfx3.Stop();
            playerController.playerAnimator.SetBool("IsRunning", false);
            isUI = true;
            answerUI[1].SetActive(true);
            stopBtm.SetActive(false);
        }
        else if(PlayerController.currentUI == 3)
        {
            sfx3.Stop();
            playerController.playerAnimator.SetBool("IsRunning", false);
            isUI = true;
            answerUI[2].SetActive(true);
            stopBtm.SetActive(false);
        }
        else if(PlayerController.currentUI == 4)
        {
            sfx3.Stop();
            playerController.playerAnimator.SetBool("IsRunning", false);
            isUI = true;
            answerUI[3].SetActive(true);
            stopBtm.SetActive(false);
        }
        else if(PlayerController.currentUI == 5)
        {
            sfx3.Stop();
            playerController.playerAnimator.SetBool("IsRunning", false);
            isUI = true;
            answerUI[4].SetActive(true);
            stopBtm.SetActive(false);
        }
    }

    public void CheckAnswer()
    {
        if(isWrong == false)
        {
            if(playerAns[0].GetComponent<Text>().text == "24747" && PlayerController.currentUI == 1)
            {
                isUI = false;
                stopBtm.SetActive(true);
                allDoor[0].SetActive(false);
                PlayerController.currentUI = 0;
                answerUI[0].SetActive(false);
                StartCoroutine(Correct());
            }
            else if(playerAns[1].GetComponent<Text>().text == "1" && PlayerController.currentUI == 2)
            {
                isUI = false;
                stopBtm.SetActive(true);
                allDoor[1].SetActive(false);
                PlayerController.currentUI = 0;
                answerUI[1].SetActive(false);
                StartCoroutine(Correct());
            }
            else if(playerAns[2].GetComponent<Text>().text == "4685" && PlayerController.currentUI == 3)
            {
                isUI = false;
                stopBtm.SetActive(true);
                allDoor[2].SetActive(false);
                PlayerController.currentUI = 0;
                answerUI[2].SetActive(false);
                StartCoroutine(Correct());
            }
            else if(playerAns[3].GetComponent<Text>().text == "00" && PlayerController.currentUI == 4)
            {
                isUI = false;
                stopBtm.SetActive(true);
                allDoor[3].SetActive(false);
                PlayerController.currentUI = 0;
                answerUI[3].SetActive(false);
                StartCoroutine(Correct());
            }
            else if(playerAns[4].GetComponent<Text>().text == "12" && PlayerController.currentUI == 5)
            {
                isUI = false;
                stopBtm.SetActive(true);
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
    }

    public void ShowQuestion()
    {
        if(PlayerController.currentQuestion == 1)
        {
            sfx3.Stop();
            sfx2.Play();
            playerController.playerAnimator.SetBool("IsRunning", false);
            isUI = true;
            questionUI[0].SetActive(true);
            stopBtm.SetActive(false);
        }
        else if(PlayerController.currentQuestion == 2)
        {
            sfx3.Stop();
            sfx2.Play();
            playerController.playerAnimator.SetBool("IsRunning", false);
            isUI = true;
            questionUI[1].SetActive(true);
            stopBtm.SetActive(false);
        }
        else if(PlayerController.currentQuestion == 3)
        {
            sfx3.Stop();
            sfx2.Play();
            playerController.playerAnimator.SetBool("IsRunning", false);
            isUI = true;
            questionUI[2].SetActive(true);
            stopBtm.SetActive(false);
        }
        else if(PlayerController.currentQuestion == 4)
        {
            sfx3.Stop();
            sfx2.Play();
            playerController.playerAnimator.SetBool("IsRunning", false);
            isUI = true;
            questionUI[3].SetActive(true);
            stopBtm.SetActive(false);
        }
        else if(PlayerController.currentQuestion == 5)
        {
            sfx3.Stop();
            sfx2.Play();
            playerController.playerAnimator.SetBool("IsRunning", false);
            isUI = true;
            questionUI[4].SetActive(true);
            stopBtm.SetActive(false);
        }
    }

    public void GetElement()
    {
        if(finishedQuestion == "Fire")
        {
            sfx1.Play();
            emptyImage[gotElement].GetComponent<Image>().sprite = images[currentElement];
            gotElement += 1;
            isWon();
        }
        if(finishedQuestion == "Wood")
        {
            sfx1.Play();
            emptyImage[gotElement].GetComponent<Image>().sprite = images[currentElement];
            gotElement += 1;
            isWon();
        }
        if(finishedQuestion == "Water")
        {
            sfx1.Play();
            emptyImage[gotElement].GetComponent<Image>().sprite = images[currentElement];
            gotElement += 1;
            isWon();
        }
        if(finishedQuestion == "Gold")
        {
            sfx1.Play();
            emptyImage[gotElement].GetComponent<Image>().sprite = images[currentElement];
            gotElement += 1;
            isWon();
        }
        if(finishedQuestion == "Dust")
        {
            sfx1.Play();
            emptyImage[gotElement].GetComponent<Image>().sprite = images[currentElement];
            gotElement += 1;
            isWon();
        }
    }

    public void isWon()
    {
        if(gotElement == 5)
        {
            checkWon = true;
            stopBtm.SetActive(false);
            playerController.playerAnimator.SetBool("IsRunning", false);
            sfx3.Stop();
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
        if(isWrong == false)
        {
            for(int i = 0; i < answerUI.Length; i++)
            {
                answerUI[i].SetActive(false);
            }
            PlayerController.currentUI = 0;
            isUI = false;
            stopBtm.SetActive(true);
        }
    }

    IEnumerator Wrong()
    {
        isWrong = true;
        for(int i = 0; i <= 2; i++)
        {
            wrongUI.SetActive(true);
            yield return new WaitForSeconds(1f);
            wrongUI.SetActive(false);
            yield return new WaitForSeconds(0.3f);
        }
        isWrong = false;
    }

    IEnumerator Correct()
    {
        for(int i = 0; i <= 1; i++)
        {
            correctTxt.SetActive(true);
            yield return new WaitForSeconds(0.6f);
            correctTxt.SetActive(false);
            yield return new WaitForSeconds(0.3f);
        }
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
        audio.Pause();
        sfx3.Stop();
        gameUI.SetActive(false);
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        gameIsPause = false;
        audio.Play();
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
}
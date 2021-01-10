using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage1Controller : MonoBehaviour
{
    [SerializeField] private GameObject gameUI = null;
    [SerializeField] private GameObject pauseUI = null;
    [SerializeField] private GameObject tipsUI = null;
    [SerializeField] private Text timeTxt = null;
    [SerializeField] private GameObject WinTxt = null;
    [SerializeField] private GameObject pauseBtn = null;
    [SerializeField] private new AudioSource audio = null;
    public AudioSource sfx1 = null;
    public AudioSource sfx2 = null;
    [SerializeField] private GameObject[] boxImage = null;
    [SerializeField] private GameObject[] emptyImage = null;
    [HideInInspector] public int completeBox;
    private Player player;
    private bool isUI;
    private bool gameIsPause;
    private float timeLeft;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        SceneController.currentStage = "Stage1";
        Time.timeScale = 0f;
        completeBox = 0;
        timeLeft = 180f;
        gameIsPause = false;
        isUI = true;
        tipsUI.SetActive(true);
        gameUI.SetActive(true);
        pauseUI.SetActive(false);
        sfx1.volume = PlayerPrefs.GetFloat("sfxVolume", 1f);
        sfx2.volume = PlayerPrefs.GetFloat("sfxVolume", 1f);
        audio.volume = PlayerPrefs.GetFloat("audioVolume", 1f);
    }

    private void Update()
    {
        CheckESC();
        TimeCount();
    }

    private void CheckESC()
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
    }

    private void TimeCount()
    {
        if(completeBox < 5)
        {
            timeLeft -= Time.deltaTime;
            timeTxt.text = "剩餘時間: " + (int)timeLeft + "s";
            if(timeLeft <= 90f)
            {
                timeTxt.color = Color.yellow;
            }
            if(timeLeft <= 45f)
            {
                timeTxt.color = Color.red;
            }
            if(timeLeft <= 0f)
            {
                SceneManager.LoadScene("Ending2");
            }
        }
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
            player.playerAnimator.SetBool("IsRunning", false);
            sfx2.Stop();
            WinTxt.SetActive(true);
            pauseBtn.SetActive(false);
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
        audio.Pause();
        sfx2.Stop();
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
}
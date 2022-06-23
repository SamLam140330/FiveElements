using FiveElement.Id;
using FiveElement.Stage1;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FiveElement.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeTxt;
        [SerializeField] private GameObject tipsUI;
        [SerializeField] private GameObject gameUI;
        [SerializeField] private GameObject pauseUI;
        [SerializeField] private GameObject completeUI;
        [SerializeField] private Image[] emptyElements;
        [SerializeField] private Sprite[] elements;

        private void Awake()
        {
            tipsUI.SetActive(true);
            gameUI.SetActive(false);
            pauseUI.SetActive(false);
            completeUI.SetActive(false);
        }

        private void Update()
        {
            if (StageManager.FindElementNum < 5 && StageManager.IsPause == false)
            {
                ChangeTimerTxt();
            }
        }

        private void OnEnable()
        {
            Stage1Controller.OnCompleteElement += ChangeCompleteElementState;
            StageManager.OnPauseTheGame += ChangeGamePauseState;
        }

        private void OnDisable()
        {
            Stage1Controller.OnCompleteElement -= ChangeCompleteElementState;
            StageManager.OnPauseTheGame -= ChangeGamePauseState;
        }

        private void ChangeCompleteElementState(string color)
        {
            if (color == "Gold")
            {
                emptyElements[StageManager.FindElementNum - 1].sprite = elements[0];
            }
            else if (color == "Wood")
            {
                emptyElements[StageManager.FindElementNum - 1].sprite = elements[1];
            }
            else if (color == "Dust")
            {
                emptyElements[StageManager.FindElementNum - 1].sprite = elements[2];
            }
            else if (color == "Water")
            {
                emptyElements[StageManager.FindElementNum - 1].sprite = elements[3];
            }
            else if (color == "Fire")
            {
                emptyElements[StageManager.FindElementNum - 1].sprite = elements[4];
            }
            if (StageManager.FindElementNum >= 5)
            {
                ChangeWinUi();
            }
        }

        private void ChangeGamePauseState(bool isPause)
        {
            if (isPause == false)
            {
                OnPauseClicked();
            }
            else
            {
                OnResumeClicked();
            }
        }

        private void ChangeTimerTxt()
        {
            timeTxt.text = "Time Remain: " + (int)StageManager.TimeLeft + "s";
            if (StageManager.TimeLeft <= 180f)
            {
                timeTxt.color = Color.yellow;
            }
            if (StageManager.TimeLeft <= 60f)
            {
                timeTxt.color = Color.red;
            }
        }

        private void ChangeWinUi()
        {
            completeUI.SetActive(true);
        }

        public void OnConfirmBtnClicked()
        {
            StageManager.IsTipsShow = true;
            StageManager.IsPause = false;
            tipsUI.SetActive(false);
            gameUI.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }

        public void OnPauseClicked()
        {
            StageManager.IsPause = true;
            gameUI.SetActive(false);
            pauseUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            StageManager.MakeSomeAudio(AudioState.Pause, 0);
            StageManager.MakeSomeAudio(AudioState.Stop, 2);
            Time.timeScale = 0f;
        }

        public void OnResumeClicked()
        {
            StageManager.IsPause = false;
            gameUI.SetActive(true);
            pauseUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            StageManager.MakeSomeAudio(AudioState.Play, 0);
            Time.timeScale = 1f;
        }

        public void OnBackToMenuClicked()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void OnRestartClicked()
        {
            SceneManager.LoadScene("Stage1");
        }

        public void OnQuitGameClicked()
        {
            Application.Quit();
        }
    }
}

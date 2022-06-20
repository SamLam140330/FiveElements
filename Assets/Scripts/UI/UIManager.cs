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
        [SerializeField] private GameObject pauseBtn;
        [SerializeField] private GameObject tipsUI;
        [SerializeField] private GameObject gameUI;
        [SerializeField] private GameObject pauseUI;
        [SerializeField] private GameObject completeUI;
        [SerializeField] private Image[] emptyElements;
        [SerializeField] private Sprite[] elements;

        private void Start()
        {
            tipsUI.SetActive(true);
            gameUI.SetActive(false);
            pauseUI.SetActive(false);
            completeUI.SetActive(false);
        }

        private void Update()
        {
            CheckEscBtn();
            ChangeTimerTxt();
        }

        private void OnEnable()
        {
            Stage1Manager.OnCompleteElement += ChangeCompleteElementState;
        }

        private void OnDisable()
        {
            Stage1Manager.OnCompleteElement -= ChangeCompleteElementState;
        }

        private void ChangeCompleteElementState(string color)
        {
            if (color == "Gold")
            {
                emptyElements[Stage1Manager.FindElementNum - 1].sprite = elements[0];
            }
            else if (color == "Wood")
            {
                emptyElements[Stage1Manager.FindElementNum - 1].sprite = elements[1];
            }
            else if (color == "Dust")
            {
                emptyElements[Stage1Manager.FindElementNum - 1].sprite = elements[2];
            }
            else if (color == "Water")
            {
                emptyElements[Stage1Manager.FindElementNum - 1].sprite = elements[3];
            }
            else if (color == "Fire")
            {
                emptyElements[Stage1Manager.FindElementNum - 1].sprite = elements[4];
            }
            if (Stage1Manager.FindElementNum >= 5)
            {
                ChangeWinUi();
            }
        }

        private void CheckEscBtn()
        {
            if (Stage1Manager.FindElementNum < 5 && Stage1Manager.TimeLeft > 0)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (Stage1Manager.IsPause == false)
                    {
                        OnPauseClicked();
                    }
                    else
                    {
                        OnResumeClicked();
                    }
                }
            }
        }

        private void ChangeTimerTxt()
        {
            if (Stage1Manager.FindElementNum < 5)
            {
                timeTxt.text = "Time Remain: " + (int)Stage1Manager.TimeLeft + "s";
                if (Stage1Manager.TimeLeft <= 180f)
                {
                    timeTxt.color = Color.yellow;
                }
                if (Stage1Manager.TimeLeft <= 60f)
                {
                    timeTxt.color = Color.red;
                }
            }
        }

        private void ChangeWinUi()
        {
            completeUI.SetActive(true);
            pauseBtn.SetActive(false);
        }

        public void OnConfirmBtnClicked()
        {
            Stage1Manager.IsPause = false;
            tipsUI.SetActive(false);
            gameUI.SetActive(true);
            Time.timeScale = 1f;
        }

        public void OnPauseClicked()
        {
            Stage1Manager.IsPause = true;
            gameUI.SetActive(false);
            pauseUI.SetActive(true);
            Stage1Manager.MakeSomeAudio(AudioState.Pause, 0);
            Stage1Manager.MakeSomeAudio(AudioState.Stop, 2);
            Time.timeScale = 0f;
        }

        public void OnResumeClicked()
        {
            Stage1Manager.IsPause = false;
            gameUI.SetActive(true);
            pauseUI.SetActive(false);
            Stage1Manager.MakeSomeAudio(AudioState.Play, 0);
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

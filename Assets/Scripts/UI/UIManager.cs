using FiveElement.Id;
using FiveElement.GameManager;
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
        [SerializeField] private GameObject fadeInOutUI;
        [SerializeField] private GameObject endingUI;
        [SerializeField] private Image endingImage;
        [SerializeField] private Sprite[] images;
        [SerializeField] private Image[] emptyElements;
        [SerializeField] private Sprite[] elements;
        [SerializeField] private Animator[] animator;
        private readonly int _opening = Animator.StringToHash("Opening");

        private void Start()
        {
            if (StageManager.SceneStages == SceneStage.Opening)
            {
                fadeInOutUI.SetActive(true);
                animator[0].SetTrigger(_opening);
            }
            else if (StageManager.SceneStages == SceneStage.Ending1)
            {
                endingImage.sprite = images[0];
                endingUI.SetActive(true);
            }
            else if (StageManager.SceneStages is SceneStage.Stage1 or SceneStage.Stage2 or SceneStage.Stage3)
            {
                tipsUI.SetActive(true);
            }
            else if (StageManager.SceneStages == SceneStage.Ending2)
            {
                endingImage.sprite = images[1];
                endingUI.SetActive(true);
            }
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

        public void OnFadeInOutYesBtnClicked()
        {
            if (StageManager.SceneStages == SceneStage.Opening)
            {
                SceneManager.LoadScene(SceneStage.Stage1.ToString());
            }
            else
            {
                SceneManager.LoadScene(StageManager.LossStage.ToString());
            }
        }

        public void OnFadeInOutNoBtnClicked()
        {
            if (StageManager.SceneStages == SceneStage.Opening)
            {
                SceneManager.LoadScene(SceneStage.Ending1.ToString());
            }
            else
            {
                SceneManager.LoadScene(SceneStage.MainMenu.ToString());
            }
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
            SceneManager.LoadScene(SceneStage.MainMenu.ToString());
        }

        public void OnRestartClicked()
        {
            SceneManager.LoadScene(StageManager.SceneStages.ToString());
        }

        public void OnQuitGameClicked() //may remove
        {
            Application.Quit();
        }
    }
}

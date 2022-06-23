using System.Collections;
using FiveElement.Id;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FiveElement.Stage1
{
    public abstract class StageManager : MonoBehaviour
    {
        public static int FindElementNum;
        public static float TimeLeft;
        public static bool IsPause;
        public static bool IsTipsShow;
        private static StageManager _stageManager;

        public delegate void PlayAudio(AudioState state, int audioIndex);
        public static event PlayAudio OnChangeAudioState;
        public delegate void CheckEsc(bool isPause);
        public static event CheckEsc OnPauseTheGame;

        public static void MakeSomeAudio(AudioState state, int audioIndex)
        {
            OnChangeAudioState?.Invoke(state, audioIndex);
        }

        public static void PauseTheGame(bool isPause)
        {
            OnPauseTheGame?.Invoke(isPause);
        }

        private void Awake()
        {
            //PlayerPrefs.SetInt("Stage", 1);
            PlayerPrefs.Save();
            _stageManager = GetComponent<StageManager>();
            FindElementNum = 0;
            TimeLeft = 400f;
            IsTipsShow = false;
            IsPause = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }

        private void Update()
        {
            if (IsPause == false && TimeLeft > 0 && FindElementNum < 5)
            {
                Timer();
            }
        }

        private void Timer()
        {
            TimeLeft -= Time.deltaTime;
            if (TimeLeft <= 0f)
            {
                SceneManager.LoadScene("Ending2");
            }
        }

        protected static void OnCheckingLevelComplete()
        {
            if (FindElementNum >= 5)
            {
                IsPause = true;
                _stageManager.StartCoroutine(NextLevel());
            }
        }

        private static IEnumerator NextLevel()
        {
            yield return new WaitForSeconds(5f);
            //SceneManager.LoadScene("Stage2");
            Application.Quit();
        }
    }
}

using System.Collections;
using FiveElement.Id;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FiveElement.GameManager
{
    public abstract class StageManager : MonoBehaviour
    {
        public static int FindElementNum;
        public static float TimeLeft;
        public static bool IsPause;
        public static bool IsTipsShow;
        public static SceneStage SceneStages;
        public static SceneStage LossStage;
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

        protected virtual void Awake()
        {
            Cursor.lockState = CursorLockMode.None;
            _stageManager = GetComponent<StageManager>();
        }

        protected virtual void Update()
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
                if (SceneStages == SceneStage.Stage1)
                {
                    LossStage = SceneStage.Stage1;
                }
                SceneManager.LoadScene(SceneStage.Ending2.ToString());
            }
        }

        protected static void OnCheckingLevelComplete()
        {
            if (FindElementNum >= 5)
            {
                IsPause = true;
                if (SceneStages == SceneStage.Stage1)
                {
                    _stageManager.StartCoroutine(NextLevel(SceneStage.Stage2));
                }
                else if (SceneStages == SceneStage.Stage2)
                {
                    _stageManager.StartCoroutine(NextLevel(SceneStage.Stage3));
                }
                else if (SceneStages == SceneStage.Stage2)
                {
                    _stageManager.StartCoroutine(NextLevel(SceneStage.Ending3));
                }
            }
        }

        private static IEnumerator NextLevel(SceneStage stage)
        {
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene(stage.ToString());
        }
    }
}

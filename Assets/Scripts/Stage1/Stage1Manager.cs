using System.Collections;
using FiveElement.Id;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FiveElement.Stage1
{
    public class Stage1Manager : MonoBehaviour
    {
        public static int FindElementNum;
        public static float TimeLeft;
        public static bool IsPause;
        public delegate void CompleteElement(string color);
        public static event CompleteElement OnCompleteElement;
        public delegate void PlayAudio(AudioState state, int audioIndex);
        public static event PlayAudio OnChangeAudioState;

        public void GetAnElement(string color)
        {
            OnCompleteElement?.Invoke(color);
            CheckWin();
        }

        public static void MakeSomeAudio(AudioState state, int audioIndex)
        {
            OnChangeAudioState?.Invoke(state, audioIndex);
        }

        private void Start()
        {
            //PlayerPrefs.SetInt("Stage", 1);
            PlayerPrefs.Save();
            FindElementNum = 0;
            TimeLeft = 400f;
            IsPause = true;
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

        private void CheckWin()
        {
            if (FindElementNum >= 5)
            {
                IsPause = true;
                StartCoroutine(NextLevel());
            }
        }

        IEnumerator NextLevel()
        {
            yield return new WaitForSeconds(5f);
            //SceneManager.LoadScene("Stage2");
            Application.Quit();
        }
    }
}

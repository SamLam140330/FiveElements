using UnityEngine;
using UnityEngine.SceneManagement;

namespace FiveElement.Opening
{
    public class SceneController : MonoBehaviour
    {
        private int _currentStage;

        private void Start()
        {
            Time.timeScale = 1f;
            _currentStage = PlayerPrefs.GetInt("Stage");
        }

        public void Yes()
        {
            SceneManager.LoadScene("Stage1");
        }

        public void No()
        {
            SceneManager.LoadScene("Ending1");
        }

        public void OnRetryBtnClicked()
        {
            if (_currentStage == 1)
            {
                SceneManager.LoadScene("Stage1");
            }
            else if (_currentStage == 2)
            {
                SceneManager.LoadScene("Stage2");
            }
            else if (_currentStage == 3)
            {
                SceneManager.LoadScene("Stage3");
            }
        }

        public void GiveUp()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void Finish()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

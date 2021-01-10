using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private new AudioSource audio = null;
    public static string currentStage;

    private void Start()
    {
        Time.timeScale = 1f;
        audio.volume = PlayerPrefs.GetFloat("audioVolume", 1);
    }

   public void Yes()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void No()
    {
        SceneManager.LoadScene("Ending1");
    }

    public void CheckStage()
    {
        if(currentStage == "Stage1")
        {
            SceneManager.LoadScene("Stage1");
        }
        else if(currentStage == "Stage2")
        {
            SceneManager.LoadScene("Stage2");
        }
        else if(currentStage == "Stage3")
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
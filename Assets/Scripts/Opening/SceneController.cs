using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static int currentStage;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CheckStage();
        }
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
        if(currentStage == 1)
        {
            SceneManager.LoadScene("Stage1");
        }
        else if(currentStage == 2)
        {
            SceneManager.LoadScene("Stage2");
        }
        else if(currentStage == 3)
        {
            SceneManager.LoadScene("Stage3");
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
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
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2End : MonoBehaviour
{
    public Text record;
    
    void Start()
    {
        record.GetComponent<Text>().text = "";
        
    }

    public void Submit()
    {
        if(record.text == "金 木 土 水 火 ")
        {
            SceneManager.LoadScene("Stage3");
        }
        else if(record.text == "木 土 水 火 金 ")
        {
            SceneManager.LoadScene("Stage3");
        }
        else if(record.text == "土 水 火 金 木 ")
        {
            SceneManager.LoadScene("Stage3");
        }
        else if(record.text == "水 火 金 木 土 ")
        {
            SceneManager.LoadScene("Stage3");
        }
        else if(record.text == "火 金 木 土 水 ")
        {
            SceneManager.LoadScene("Stage3");
        }
        else
        {
            SceneManager.LoadScene("Ending2");
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

public class collect : MonoBehaviour
{
    public BoxManager other;
    public Text record;
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Fire" )
        {
            other.gameObject.SetActive(false);
            record.text += "火 ";
        }

        if(other.gameObject.name == "Water")
        {
            other.gameObject.SetActive(false);
            record.text += "水 ";
        }
        if (other.gameObject.name == "Wood")
        {
            other.gameObject.SetActive(false);
            record.text += "木 ";
        }
        if (other.gameObject.name == "Gold")
        {
            other.gameObject.SetActive(false);
            record.text += "金 ";
        }
        if (other.gameObject.name == "Dust")
        {
            other.gameObject.SetActive(false);
            record.text += "土 ";
        }
    }
}
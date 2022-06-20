using UnityEngine;

namespace FiveElement.Stage1
{
    public class DevelopmentBuildOnly : MonoBehaviour
    {
        private void Start()
        {
            if (PlayerPrefs.HasKey("audioVolume"))
            {
                PlayerPrefs.DeleteAll();
            }
            PlayerPrefs.SetInt("Stage", 1);
            PlayerPrefs.Save();
        }
    }
}

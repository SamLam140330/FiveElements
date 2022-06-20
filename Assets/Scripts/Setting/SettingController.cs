using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FiveElement.Setting
{
    public class SettingController : MonoBehaviour
    {
        [SerializeField] private Dropdown resolutionDropdown = null;
        [SerializeField] private Slider audioSlider = null;
        [SerializeField] private Slider sfxSlider = null;
        [SerializeField] private Dropdown quality = null;
        [SerializeField] private Dropdown fps = null;
        [SerializeField] private Dropdown resolution = null;
        [SerializeField] private Toggle isFullScreen = null;
        [SerializeField] private Toggle isVsync = null;
        [SerializeField] private new AudioSource audio = null;
        [SerializeField] private AudioSource sfx = null;
        private Resolution[] resolutions;
        private bool isOn = true;
        private bool vsyncOn = false;

        private void Start()
        {
            resolutions = Screen.resolutions;
            resolutionDropdown.ClearOptions();
            List<string> options = new List<string>();
            for(int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);
            }
            resolutionDropdown.AddOptions(options);
            resolutionDropdown.RefreshShownValue();
            quality.value = PlayerPrefs.GetInt("qualityLevel", 5);
            fps.value = PlayerPrefs.GetInt("fpsLevel", 1);
            resolution.value = PlayerPrefs.GetInt("resolutionLevel", 1);
            audio.volume = PlayerPrefs.GetFloat("audioVolume", 1);
            sfx.volume = PlayerPrefs.GetFloat("sfxVolume", 1);
            audioSlider.value = PlayerPrefs.GetFloat("audioVolume", 1f);
            sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume", 1f);
            if(PlayerPrefs.GetInt("isFullScreenMode") == 1)
            {
                isOn = true;
            }
            else
            {
                isOn = false;
            }
            isFullScreen.isOn = isOn;
            if(PlayerPrefs.GetInt("isVsyncMode") == 1)
            {
                vsyncOn = true;
            }
            else
            {
                vsyncOn = false;
            }
            isVsync.isOn = vsyncOn;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                QuitSetting();
            }
        }

        public void SetResolution(int resolutionsIndex)
        {
            Resolution resolution = resolutions[resolutionsIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        public void SetFullscreen(bool fullscreenMode)
        {
            Screen.fullScreen = fullscreenMode;
            if(fullscreenMode == true)
            {
                PlayerPrefs.SetInt("isFullScreenMode", 1);
            }
            else
            {
                PlayerPrefs.SetInt("isFullScreenMode", 0);
            }
        }

        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        public void SetFps(int fpsIndex)
        {
            if(fpsIndex == 0)
            {
                Application.targetFrameRate = 30;
                PlayerPrefs.SetInt("currentFps", 30);
            }
            else if(fpsIndex == 1)
            {
                Application.targetFrameRate = 60;
                PlayerPrefs.SetInt("currentFps", 60);
            }
            else if(fpsIndex == 2)
            {
                Application.targetFrameRate = 90;
                PlayerPrefs.SetInt("currentFps", 90);
            }
            else if(fpsIndex == 3)
            {
                Application.targetFrameRate = 144;
                PlayerPrefs.SetInt("currentFps", 144);
            }
            else if(fpsIndex == 4)
            {
                Application.targetFrameRate = 165;
                PlayerPrefs.SetInt("currentFps", 165);
            }
            else if(fpsIndex == 5)
            {
                Application.targetFrameRate = 240;
                PlayerPrefs.SetInt("currentFps", 240);
            }
        }

        public void SetVsync(bool vsyncMode)
        {
            int vysncNum;
            if(vsyncMode == true)
            {
                vysncNum = 1;
                fps.interactable = false;
            }
            else
            {
                vysncNum = 0;
                fps.interactable = true;
            }
            QualitySettings.vSyncCount = vysncNum;
            PlayerPrefs.SetInt("isVsyncMode", vysncNum);
        }

        public void SetVolume(float volume)
        {
            audio.volume = volume;
        }

        public void SetSfxVolume(float volume)
        {
            sfx.volume = volume;
        }

        public void QuitSetting()
        {
            PlayerPrefs.SetInt("qualityLevel", quality.value);
            PlayerPrefs.SetInt("fpsLevel", fps.value);
            PlayerPrefs.SetInt("resolutionLevel", resolution.value);
            PlayerPrefs.SetFloat("audioVolume", audio.volume);
            PlayerPrefs.SetFloat("sfxVolume", sfx.volume);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
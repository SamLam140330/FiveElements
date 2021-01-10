using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    [SerializeField] private Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider audioSlider;
    [SerializeField] private Dropdown quality;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionsIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionsIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionsIndex;
        resolutionDropdown.RefreshShownValue();
        quality.value = PlayerPrefs.GetInt("qualityLevel", 5);
        audioSlider.value = PlayerPrefs.GetFloat("musicVolume", 0);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            QuitSetting();
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("qualityLevel", quality.value);
        float musicVolume = 0;
        audioMixer.GetFloat("musicVolume", out musicVolume);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.Save();
    }

    public void SetResolution(int resolutionsIndex)
    {
        Resolution resolution = resolutions[resolutionsIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool fullscreenMode)
    {
        Screen.fullScreen = fullscreenMode;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
    }

    public void QuitSetting()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
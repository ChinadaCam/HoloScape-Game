using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    Resolution[] resolutions;
    public Dropdown resolutionDropdown;

     void Start()
    {
       resolutions = Screen.resolutions;

       //Clear resDropdown
       resolutionDropdown.ClearOptions();

        //Create list "options"
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i=0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        //Add Options to res
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);


    }

    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log(qualityIndex);
    }

    public void setFullscreen(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;
        Debug.Log("fullscreen");
    }

}

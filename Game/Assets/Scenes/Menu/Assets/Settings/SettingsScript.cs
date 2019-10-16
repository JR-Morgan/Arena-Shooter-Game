using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SettingsScript : MonoBehaviour {


    public Dropdown resolutionDropdown;


    Resolution[] resolutions;

    void Start()
    {
        //Gets array of all screen resolutions
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        int CurrentResolutionIndex = 0;

        //Converts array to formated list
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                CurrentResolutionIndex = i;
            }
        }

        //Adds options to the drop down
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = CurrentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void ChangeResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }

    public void SetFullScreen(bool fullscreen)
    {
        Screen.SetResolution(Screen.width, Screen.height, fullscreen);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CanvasSelectionScript : MonoBehaviour {

    public Canvas MainMenu;
    public Canvas SettingsMenu;

    public void SetScreen(string Canvas)
    {
        if (Canvas == "MainMenu") {
            MainMenu.enabled = true;
            SettingsMenu.enabled = false;
        } else
        {
            MainMenu.enabled = false;
            SettingsMenu.enabled = true;
        }
            

    }

}

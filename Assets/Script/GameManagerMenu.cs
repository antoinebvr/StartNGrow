using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class GameManagerMenu : MonoBehaviour
{

    public UiManagerMenu uiManager;
    public void Awake() 
    {
        uiManager.PanelFadeIn();
        uiManager.StartButtonAnimation();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    

}

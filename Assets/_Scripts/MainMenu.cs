using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        MainMenuManager.instance.mainMenuEvents.OnPlayerPressedSettings += Deactivate;
        MainMenuManager.instance.mainMenuEvents.OnPlayerPressedMainMenu += Activate;
    }


    private void Activate()
    {
        gameObject.SetActive(true);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void StartMainScene()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Called");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}

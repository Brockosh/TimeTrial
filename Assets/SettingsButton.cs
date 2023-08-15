using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    void Start()
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
}

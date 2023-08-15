using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrialTitle : MonoBehaviour
{
    void Start()
    {
        MainMenuManager.instance.mainMenuEvents.OnPlayerPressedSettings += Deactivate;
        MainMenuManager.instance.mainMenuEvents.OnPlayerPressedMainMenu += Activate;
    }


    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void Activate()
    {
        gameObject.SetActive(true);
    }
}

using System;
using UnityEngine;
/// <summary>
/// Class to call events when player presses buttons in main menu.
/// </summary>
public class MainMenuEvents : MonoBehaviour
{
    public event Action OnPlayerPressedSettings;
    public event Action OnPlayerPressedMainMenu;

    public void CallPlayerPressedSetting()
    {
        OnPlayerPressedSettings?.Invoke();
    }

    public void CallPlayerPressedMainMenu()
    {
        OnPlayerPressedMainMenu?.Invoke();
    }
}

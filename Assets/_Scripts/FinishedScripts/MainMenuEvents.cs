using System;
using UnityEngine;

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

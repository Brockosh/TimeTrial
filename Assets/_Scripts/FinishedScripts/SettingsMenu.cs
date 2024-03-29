using UnityEngine;
/// <summary>
/// Class to control enable and disable of settings menu.
/// </summary>
public class SettingsMenu : MonoBehaviour
{
    void Start()
    {
        Deactivate();
        MainMenuManager.instance.mainMenuEvents.OnPlayerPressedSettings += Activate;
        MainMenuManager.instance.mainMenuEvents.OnPlayerPressedMainMenu += Deactivate;
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

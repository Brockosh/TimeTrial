using UnityEngine;

public class MainMenuButton : MonoBehaviour
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
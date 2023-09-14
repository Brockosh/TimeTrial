using UnityEngine;
/// <summary>
/// Class to create static instance of main menu manager.
/// </summary>
public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;
    public MainMenuEvents mainMenuEvents;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}

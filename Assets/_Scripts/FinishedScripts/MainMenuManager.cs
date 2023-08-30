using UnityEngine;

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

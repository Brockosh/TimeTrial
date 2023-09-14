using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// Class to control return to main menu button appearing when player finishes.
/// </summary>
public class ReturnToMainMenuButton : MonoBehaviour
{
    void Start()
    {
        DeactivateReturnToMainMenuButton();
        GameManager.instance.CollisionEvent.OnPlayerCollisionFinishLine += ActivateReturnToMainMenuButton;
        GetComponent<Button>().onClick.AddListener(LoadMainMenu);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void ActivateReturnToMainMenuButton()
    {
        gameObject.SetActive(true);
    }

    private void DeactivateReturnToMainMenuButton()
    {
        gameObject.SetActive(false);
    }
}

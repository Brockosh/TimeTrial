using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToMainMenuButton : MonoBehaviour
{
    void Start()
    {
        DeactivateReturnToMainMenuButton();
        GameManager.instance.CollisionEvent.OnPlayerCollisionFinishLine += ActivateReturnToMainMenuButton;
        GetComponent<Button>().onClick.AddListener(LoadMainMenu);
    }

    public void LoadMainMenu()
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToMainMenuButton : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        DeactivateReturnToMainMenuButton();
        GameManager.instance.CollisionEvent.OnPlayerCollisionFinishLine += ActivateReturnToMainMenuButton;
        GetComponent<Button>().onClick.AddListener(LoadMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
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

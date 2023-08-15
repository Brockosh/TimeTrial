using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void StartMainScene()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Called");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}

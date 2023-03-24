using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private int correctAnswers;

    private void Start()
    {
        GameManager.instance.mathEvents.OnPlayerCorrectAnswer += IncrementCorrectAnswers;
        Debug.Log(correctAnswers);
    }

    private void IncrementCorrectAnswers()
    {
        correctAnswers++;
    }

    private void Update()
    {
        CheckForEndOfScene();
    }

    private void CheckForEndOfScene()
    {
        if (correctAnswers > 2) 
        {
            SceneManager.LoadScene(0);
        }
    }
}

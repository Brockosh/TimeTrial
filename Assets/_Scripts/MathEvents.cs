using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathEvents : MonoBehaviour
{
    public event Action OnPlayerAnswerSubmitted;
    public event Action OnPlayerCorrectAnswer;
    public event Action OnPlayerCorrectAnswerTooLate;
    public event Action OnPlayerIncorrectAnswer;
    public event Action OnPlayerFinishedMathsScene;
    public event Action OnTimeUp;


    public void CallPlayerAnswerSubmitted()
    {
        OnPlayerAnswerSubmitted?.Invoke();
    }

    public void CallPlayerCorrectAnswer()
    {
        OnPlayerCorrectAnswer?.Invoke();
    }

    public void CallPlayerCorrectAnswerTooLate()
    {
        OnPlayerCorrectAnswerTooLate?.Invoke();
    }


    public void CallPlayerIncorrectAnswer()
    {
        OnPlayerIncorrectAnswer?.Invoke();
    }

    public void CallPlayerFinishedMathsScene()
    {
        OnPlayerFinishedMathsScene?.Invoke();
    }

    public void CallTimeUp()
    {
        OnTimeUp?.Invoke();
    }
}

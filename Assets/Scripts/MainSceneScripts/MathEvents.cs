using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathEvents : MonoBehaviour
{
    public event Action OnPlayerCorrectAnswer;
    public event Action OnPlayerIncorrectAnswer;
    public event Action OnPlayerFinishedMathsScene;
    public event Action OnTimeUp;

    public void CallPlayerCorrectAnswer()
    {
        OnPlayerCorrectAnswer?.Invoke();
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

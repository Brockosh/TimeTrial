using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public event Action OnPlayerHasEnteredMainScene;
    public event Action OnPreGameTimerFinished;
    public event Action OnCameraLerpComplete;

    private void Start()
    {
        CallPlayerHasEnteredMainScene();
    }
    public void CallPlayerHasEnteredMainScene()
    {
        OnPlayerHasEnteredMainScene?.Invoke();
    }

    public void CallPreGameTimerComplete()
    {
        OnPreGameTimerFinished?.Invoke();
    }
    public void CallCameraLerpCompelte()
    {
        OnCameraLerpComplete?.Invoke();
    }
}

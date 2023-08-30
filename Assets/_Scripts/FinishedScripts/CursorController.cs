using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class CursorController : MonoBehaviour
{
    void Start()
    {
       HideAndLockCursor();
       GameManager.instance.CollisionEvent.OnPlayerCollisionFinishLine += UnhideAndUnlockCursor;
    }

    private void HideAndLockCursor()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    private void UnhideAndUnlockCursor()
    {
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class CursorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       HideAndLockCursor();
        GameManager.instance.CollisionEvent.OnPlayerCollisionFinishLine += UnhideAndUnlockCursor;
    }

    // Update is called once per frame
    void Update()
    {

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

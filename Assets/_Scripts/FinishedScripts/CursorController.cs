using UnityEngine;
/// <summary>
/// Class to control cursor whether cursor is visible or not in game.
/// </summary>
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

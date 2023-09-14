using UnityEngine;
/// <summary>
/// Class to control sky dome that is enabled when the player hits obstacle 4.
/// </summary>
public class DarkSkyDome : MonoBehaviour
{
    private float y = 0.0f;
    bool canRotate;

    void Start()
    {
        RunSubscriptions();
        SetInactive();
        canRotate = false;
    }

    void Update()
    {
        Rotate();
    }

    private void ActivateRotation()
    {
        canRotate = true;
    }
    private void Rotate()
    {
        if (canRotate)
        {
            transform.localRotation = Quaternion.Euler(0, y, 0);
            y += 0.01f;
        }
    }

    private void RunSubscriptions()
    {
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += ActivateRotation;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += SetActive;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit += SetInactive;
    }
    private void SetActive()
    {
        gameObject.SetActive(true);
    }

    private void SetInactive()
    {
        gameObject.SetActive(false);
    }
}

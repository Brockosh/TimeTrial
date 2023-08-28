using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSkyDome : MonoBehaviour
{

    private float y = 0.0f;
    bool canRotate;
    void Start()
    {
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += SetActive;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += ActivateRotation;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit += SetInactive;
        SetInactive();
        canRotate = false;
    }

    // Update is called once per frame
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

    private void SetActive()
    {
        gameObject.SetActive(true);
        Debug.Log("ActiveTriggered");
    }

    private void SetInactive()
    {
        gameObject.SetActive(false);
    }
}

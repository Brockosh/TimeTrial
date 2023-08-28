using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystem : MonoBehaviour
{
    private void Start()
    {
        Deactivate();
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += SetActive;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit += Deactivate;
    }

    private void SetActive()
    {
        this.gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        this .gameObject.SetActive(false);
    }
}

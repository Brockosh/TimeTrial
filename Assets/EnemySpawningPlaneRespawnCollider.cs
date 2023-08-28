using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningPlaneRespawnCollider : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionEnemy();
        }
    }
}

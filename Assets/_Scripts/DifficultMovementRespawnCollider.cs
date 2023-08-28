using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultMovementRespawnCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionDifficultMovementPlaneRespawn();
            Debug.Log("Player should respawn");
        }
    }
}

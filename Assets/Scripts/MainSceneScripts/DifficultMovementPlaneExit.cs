using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultMovementPlaneExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("IMPACT");
            GameManager.instance.CollisionEvent.CallPlayerCollisionDifficultMovementPlaneExit();
        }
    }
}

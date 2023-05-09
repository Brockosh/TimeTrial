using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningPlaneExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionEnemySpawningPlaneExit();
            Debug.Log("CALLED");
        }
    }
}

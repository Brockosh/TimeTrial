using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallCollider : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionDifficultMovementPlaneFall();
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if ( collision.gameObject.CompareTag("Player"))
    //    {
    //        GameManager.instance.CollisionEvent.CallPlayerCollisionDifficultMovementPlaneFall();
    //    }
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningPlane : MonoBehaviour
{
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        GameManager.instance.CollisionEvent.CallPlayerCollisionEnemySpawningPlane();
    //    }
    //}

    BoxCollider myBoxCollider;

    //private void Awake()
    //{
    //    myBoxCollider = GetComponent<BoxCollider>();
    //    GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit += DisableBoxCollider;
    //}

    private void Start()
    {
        myBoxCollider = GetComponent<BoxCollider>();
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit += DisableBoxCollider;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionEnemySpawningPlane();
        }
    }

    private void DisableBoxCollider()
    {
        Debug.Log("DisableBoxCollider called");
        myBoxCollider.enabled = false;
    }
}


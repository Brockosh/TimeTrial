using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningPlaneExit : MonoBehaviour
{

    //MeshCollider myMeshCollider;

    //private void Start()
    //{
    //    myMeshCollider = GetComponent<MeshCollider>();
    //   // GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit += DisableMeshCollider;
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionEnemySpawningPlaneExit();
            Debug.Log("CALLED");
        }
    }

    //private void DisableMeshCollider()
    //{
    //    myMeshCollider.enabled = false;
    //}

    //private void Destroy()
    //{
    //    Destroy(gameObject);
    //}
}

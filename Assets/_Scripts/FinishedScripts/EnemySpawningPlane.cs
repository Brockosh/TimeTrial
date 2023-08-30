using UnityEngine;

public class EnemySpawningPlane : MonoBehaviour
{
    BoxCollider myBoxCollider;

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


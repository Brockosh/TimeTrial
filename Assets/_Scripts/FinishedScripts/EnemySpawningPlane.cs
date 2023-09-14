using UnityEngine;
/// <summary>
/// Class to control obstacle 4 functionality and collider enable/disable.
/// </summary>
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
        myBoxCollider.enabled = false;
    }
}


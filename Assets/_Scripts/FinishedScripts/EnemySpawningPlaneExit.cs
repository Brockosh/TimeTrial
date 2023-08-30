using UnityEngine;

public class EnemySpawningPlaneExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionEnemySpawningPlaneExit();
        }
    }
}

using UnityEngine;
/// <summary>
/// Class to call collision when player falls off enemy spawning plane, prompting respawn.
/// </summary>
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

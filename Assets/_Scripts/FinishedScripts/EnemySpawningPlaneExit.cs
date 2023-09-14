using UnityEngine;
/// <summary>
/// Class to call collision event when player exits enemy spawning plane.
/// </summary>
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

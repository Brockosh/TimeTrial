using UnityEngine;
/// <summary>
/// Class to call event when player falls off obstacle two, prompting respawn.
/// </summary>
public class PlayerFallCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionDifficultMovementPlaneFall();
        }
    }
}

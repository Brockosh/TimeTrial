using UnityEngine;
/// <summary>
/// Class to trigger player collision with obstacle 2 respawn collider.
/// </summary>
public class DifficultMovementRespawnCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionDifficultMovementPlaneRespawn();
        }
    }
}

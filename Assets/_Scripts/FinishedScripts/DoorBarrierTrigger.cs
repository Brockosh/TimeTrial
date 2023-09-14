using UnityEngine;
/// <summary>
/// Class to call event when player colliders with door barrier trigger.
/// </summary>
public class DoorBarrierTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionDoorBarrier();
        }
    }
}

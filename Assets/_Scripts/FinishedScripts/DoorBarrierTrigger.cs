using UnityEngine;

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

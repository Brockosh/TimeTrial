using UnityEngine;
/// <summary>
/// Class to trigger collision with obstacle 2 exit.
/// </summary>
public class DifficultMovementPlaneExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionDifficultMovementPlaneExit();
        }
    }
}

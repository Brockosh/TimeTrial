using UnityEngine;
/// <summary>
/// Class to trigger collision with obstacle 2.
/// </summary>
public class DifficultMovementPlane : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionDifficultMovementPlane();
        }
    }
}

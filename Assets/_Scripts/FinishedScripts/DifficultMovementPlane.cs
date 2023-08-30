using UnityEngine;

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

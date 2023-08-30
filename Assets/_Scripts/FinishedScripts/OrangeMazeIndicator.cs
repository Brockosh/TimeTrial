using UnityEngine;

public class OrangeMazeIndicator : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionOrangeZone();
        }
    }
}

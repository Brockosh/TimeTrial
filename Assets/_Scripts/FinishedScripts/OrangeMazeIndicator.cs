using UnityEngine;
/// <summary>
/// Class to call event when player collides with green indicator, turning maze Orange.
/// </summary>
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

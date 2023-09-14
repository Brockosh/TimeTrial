using UnityEngine;
/// <summary>
/// Class to call event when player collides with green indicator, turning maze green.
/// </summary>
public class GreenMazeIndicator : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionGreenZone();
        }
    }
}

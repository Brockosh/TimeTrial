using UnityEngine;
/// <summary>
/// Class to call event when player exits maze.
/// </summary>
public class MazeExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionMazeExit();
        }
    }
}

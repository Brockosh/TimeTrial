using UnityEngine;
/// <summary>
/// Class to call event when player enters maze.
/// </summary>
public class MazeEntrance : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionMazeEntrance();
        }
    }
}

using UnityEngine;
/// <summary>
/// Class to call event when player walks over start line.
/// </summary>
public class StartLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionStartLine();
        }
    }
}

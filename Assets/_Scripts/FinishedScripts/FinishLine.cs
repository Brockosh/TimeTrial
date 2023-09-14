using UnityEngine;
/// <summary>
/// Class to control functionality of finish line, and prevent multiple finished prompts.
/// </summary>
public class FinishLine : MonoBehaviour
{
    private AudioSource audioSource;
    private int finishCount = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && finishCount <= 0)
        {
            GameManager.instance.CollisionEvent.CallPlayerCollisionFinishLine();
            audioSource.Play();
            finishCount++;
        }
    }
}

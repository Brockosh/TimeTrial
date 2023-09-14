using UnityEngine;
/// <summary>
/// Class to control functionality of doors in obstacle 1.
/// </summary>
public class Door : MonoBehaviour
{
    public bool openable;
    public bool hasBeenOpened;
    public Transform myTransform;

    private void Start()
    {
        myTransform = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (openable && !hasBeenOpened)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OpenDoor();
                hasBeenOpened = true;
                GameManager.instance.CollisionEvent.CallPlayerCollisionCorrectDoor();
            }
        }
    }

    private void OpenDoor()
    {
        transform.Rotate(0f, 90f, 0f);
        myTransform.Translate(myTransform.right);
        myTransform.Translate(-myTransform.forward);
    }
}


using System.Collections;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    private Vector3 offset;
    public Vector3 ThirdPersonOffset = new Vector3(0, 3, -5);
    //public Vector3 FirstPersonOffest = new Vector3(0, 0, 0);
    bool inFirstPerson = false;


    private void Start()
    {
        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeEntrance += ChangeOffsetToFirstPerson;
        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeExit += SetCameraPositionToThirdPerson;
        SetCameraPositionToThirdPerson();
    }

    private void Update()
    {
        SetCameraPosition();
    }

    private void ChangeOffsetToFirstPerson()
    {
        StartCoroutine(SmoothTransitionToFirstPerson());
        //offset = new Vector3(0, 1.5f, 0);
        //inFirstPerson = true;
    }

    private void SetCameraPositionToThirdPerson()
    {
        offset = ThirdPersonOffset;
        inFirstPerson = false;
        transform.rotation = Quaternion.Euler(20, 0, 0);
    }

    private void SetCameraPosition() 
    {
        transform.position = target.position + offset;
        if (inFirstPerson)
        {
            transform.rotation = Quaternion.Euler(0, target.transform.eulerAngles.y, 0);
        }
    }

    private IEnumerator SmoothTransitionToFirstPerson()
    {
        Vector3 firstPersonOffset = new Vector3(0, 1.5f, 0);
        float duration = 1f;
        float elapsedTime = 0f;

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, target.transform.eulerAngles.y, 0);

        Vector3 startingOffset = offset;

        while (elapsedTime < duration) 
        {
            float t = elapsedTime / duration;
            offset = Vector3.Lerp(startingOffset, firstPersonOffset, t);
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        offset = firstPersonOffset;
        inFirstPerson = true;
    }
}

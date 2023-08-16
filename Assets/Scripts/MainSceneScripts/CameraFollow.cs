
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [System.Serializable]
    public class Doorway
    {
        public Transform doorTrigger;
        public Transform doorThreshold;
    }

    public Transform target;
    public float smoothSpeed = 0.125f;
    private Vector3 offset;
    public Vector3 thirdPersonOffset = new Vector3(0, 3, -5);
    public Quaternion thirdPersonRotation = Quaternion.Euler(20, 0, 0);
    //public Vector3 FirstPersonOffest = new Vector3(0, 0, 0);
    bool inFirstPerson = false;

    [Serialize] public LayerMask cameraTarget;
    public List<Doorway> doorways = new List<Doorway> ();
    private Transform currentDoorThreshhold;

    private void Start()
    {
        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeEntrance += ChangeOffsetToFirstPerson;
        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeExit += ChangeOffsetToThirdPerson;
        SetCameraPositionToThirdPerson();
    }

    private void Update()
    {
        SetCameraPosition();
        SphereCastToPlayer();
    }

    private void ChangeOffsetToFirstPerson()
    {
        StartCoroutine(SmoothTransitionToFirstPerson());
    }

    private void ChangeOffsetToThirdPerson()
    {
        StartCoroutine(SmoothTransitionToThirdPerson());
    }

    private void SetCameraPositionToThirdPerson()
    {
        offset = thirdPersonOffset;
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
        float duration = 1f;
        float elapsedTime = 0f;

        Quaternion startRotation = transform.rotation;
        Vector3 startingOffset = offset;

        Quaternion endRotation = Quaternion.Euler(0, target.transform.eulerAngles.y, 0);
        Vector3 firstPersonOffset = new Vector3(0, 1.5f, 0);

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

    private IEnumerator SmoothTransitionToThirdPerson()
    {
        float duration = 1f;
        float elapsedTime = 0f;

    
        Vector3 startingOffset = offset;
        Quaternion startRotation = transform.rotation;

     
        Vector3 endOffset = thirdPersonOffset;
        Quaternion endRotation = thirdPersonRotation; 

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            offset = Vector3.Lerp(startingOffset, endOffset, t);
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        offset = endOffset;
        transform.rotation = endRotation;
        inFirstPerson = false;
    }

    private void AdjustCameraHeightBasedOnDoorwayPosition()
    {
        float distBetweenPlayerAndThresh = Vector3.Distance(target.position, currentDoorThreshhold.position);
        float maxDoorwayDistance = 3.0f;
        float t = Mathf.Clamp01(distBetweenPlayerAndThresh / maxDoorwayDistance);

        float desiredCameraHeight = Mathf.Lerp(thirdPersonOffset.y - 2f, thirdPersonOffset.y, t);
        offset.y = desiredCameraHeight;
    }

    private void SphereCastToPlayer()
    {
        RaycastHit hit;
        float radius = 0.002f;
        Vector3 directionToPlayer = target.position - transform.position;
        float maxDistance = Vector3.Distance(target.position, transform.position);

        Debug.DrawLine(transform.position, target.position, Color.red, 2.0f);

        if (Physics.SphereCast(transform.position, radius, directionToPlayer, out hit, maxDistance, cameraTarget))
        {
            // Check if you hit a wall or door
            if (hit.collider.CompareTag("CameraDoorTrigger"))
            {
                currentDoorThreshhold = doorways.Find(doorway => doorway.doorTrigger == hit.collider.transform).doorThreshold;
                AdjustCameraHeightBasedOnDoorwayPosition();


            }
        }
        else
        {
            offset.y = Mathf.Lerp(offset.y, 3, 3f);
        }
    }





}

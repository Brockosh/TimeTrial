using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class for all the functionality of main camera, including lerps and raycasts.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    // Serializable class to hold door-related information
    [System.Serializable]
    public class Doorway
    {
        public Transform doorTrigger;
        public Transform doorThreshold;
    }

    [SerializeField] private Transform target;
    private Vector3 offsetFromTarget;
    private bool inFirstPerson = false;
    private Vector3 thirdPersonOffset = new Vector3(0, 3, -5);
    private Quaternion thirdPersonRotation = Quaternion.Euler(20, 0, 0);

    // Variables for collision detection and doorways
    [SerializeField] private LayerMask cameraTarget;
    private Transform currentDoorThreshhold;
    public List<Doorway> doorways = new List<Doorway>();

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
        // Set the offset and rotation for third-person view
        offsetFromTarget = thirdPersonOffset;
        inFirstPerson = false;
        transform.rotation = thirdPersonRotation;
    }

    private void SetCameraPosition()
    {
        // Set the camera position based on the target and the offset
        transform.position = target.position + offsetFromTarget;

        // Update rotation if in first-person view
        if (inFirstPerson)
        {
            transform.rotation = Quaternion.Euler(0, target.transform.eulerAngles.y, 0);
        }
    }

    private IEnumerator SmoothTransitionToFirstPerson()
    {
        // Initialize variables
        float duration = 1f;
        float elapsedTime = 0f;

        // Starting rotation and position
        Quaternion startRotation = transform.rotation;
        Vector3 startingOffset = offsetFromTarget;

        // Ending rotation and position for first-person view
        Quaternion endRotation = Quaternion.Euler(0, target.transform.eulerAngles.y, 0);
        Vector3 firstPersonOffset = new Vector3(0, 1.5f, 0);

        // Loop to interpolate between the starting and ending positions and rotations
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            offsetFromTarget = Vector3.Lerp(startingOffset, firstPersonOffset, t);
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Apply final first-person settings
        offsetFromTarget = firstPersonOffset;
        inFirstPerson = true;
    }

    // Coroutine to smoothly transition the camera from first-person to third-person view
    private IEnumerator SmoothTransitionToThirdPerson()
    {
        // Duration of the transition in seconds
        float duration = 1f;
        // Elapsed time since the transition started
        float elapsedTime = 0f;

        // Store the starting camera offset and rotation before the transition
        Vector3 startingOffset = offsetFromTarget;
        Quaternion startRotation = transform.rotation;

        // Define the desired ending camera offset and rotation for third-person view
        Vector3 endOffset = thirdPersonOffset;
        Quaternion endRotation = thirdPersonRotation;

        // Loop to perform the smooth transition
        while (elapsedTime < duration)
        {
            // Calculate interpolation factor
            float t = elapsedTime / duration;

            // Interpolate camera offset and rotation based on the interpolation factor
            offsetFromTarget = Vector3.Lerp(startingOffset, endOffset, t);
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Yield execution to the next frame
            yield return null;
        }
        // Apply the final offset and rotation for third-person view
        offsetFromTarget = endOffset;
        transform.rotation = endRotation;

        // Update the view mode to indicate we are now in third-person view
        inFirstPerson = false;
    }

    // Method for adjusting camera height when near doorways
    private void AdjustCameraHeightBasedOnDoorwayPosition()
    {
        // Calculate the distance between the player and the doorway threshold
        float distBetweenPlayerAndThresh = Vector3.Distance(target.position, currentDoorThreshhold.position);

        // Maximum allowable distance to still affect the camera
        float maxDoorwayDistance = 3.0f;

        // Clamp the ratio between the actual distance and max distance to [0, 1]
        float t = Mathf.Clamp01(distBetweenPlayerAndThresh / maxDoorwayDistance);

        // Interpolate the camera height based on how close the player is to the doorway
        float desiredCameraHeight = Mathf.Lerp(thirdPersonOffset.y - 2f, thirdPersonOffset.y, t);
        offsetFromTarget.y = desiredCameraHeight;
    }


    // Function to perform a sphere cast to detect any obstructions between the camera and the player
    private void SphereCastToPlayer()
    {
        if (inFirstPerson) { return; }

        // Initialize variables for sphere casting
        RaycastHit hit;
        float radius = 0.002f;
        Vector3 directionToPlayer = target.position - transform.position;
        float maxDistance = Vector3.Distance(target.position, transform.position);

        // For debugging: draw a line from the camera to the player
        Debug.DrawLine(transform.position, target.position, Color.red, 2.0f);


        if (Physics.SphereCast(transform.position, radius, directionToPlayer, out hit, maxDistance, cameraTarget))
        {
            if (hit.collider.CompareTag("CameraDoorTrigger"))
            {
                // Find the corresponding doorway and update currentDoorThreshhold
                currentDoorThreshhold = doorways.Find(doorway => doorway.doorTrigger == hit.collider.transform).doorThreshold;
                AdjustCameraHeightBasedOnDoorwayPosition();
            }
        }
        else
        {
            // If no obstructions were hit, adjust the camera's height back to the original offset
            offsetFromTarget.y = Mathf.Lerp(offsetFromTarget.y, thirdPersonOffset.y, Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Serializable class to hold door-related information
    [System.Serializable]
    public class Doorway
    {
        public Transform doorTrigger;  
        public Transform doorThreshold;  
    }

    private Vector3 offset;  // The distance between the target and the camera
    private bool inFirstPerson = false;  // Flag to indicate whether in first-person view

   
    public Transform target;  // The target that the camera will follow
    public float smoothSpeed = 0.125f;  // Speed factor for smoothing camera movement
    public Vector3 thirdPersonOffset = new Vector3(0, 3, -5);  // The offset for third-person view
    public Quaternion thirdPersonRotation = Quaternion.Euler(20, 0, 0);  // The default rotation in third-person view
    

    // Variables for collision detection and doorways
    [SerializeField] public LayerMask cameraTarget;  
    public List<Doorway> doorways = new List<Doorway>();  
    private Transform currentDoorThreshhold;  

    private void Start()
    {
        // Subscribe to collision events to toggle between first-person and third-person views
        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeEntrance += ChangeOffsetToFirstPerson;
        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeExit += ChangeOffsetToThirdPerson;

        // Set the initial camera position to third-person
        SetCameraPositionToThirdPerson();
    }

    private void Update()
    {
        // Update the camera position and perform sphere cast to for doorway lerp
        SetCameraPosition();
        SphereCastToPlayer();
    }

    // Event handler to switch to first-person view
    private void ChangeOffsetToFirstPerson()
    {
        // Start a Coroutine for a smooth transition to first-person view
        StartCoroutine(SmoothTransitionToFirstPerson());
    }

    // Event handler to switch to third-person view
    private void ChangeOffsetToThirdPerson()
    {
        // Start a Coroutine for a smooth transition to third-person view
        StartCoroutine(SmoothTransitionToThirdPerson());
    }

    // Function to set the camera to third-person view
    private void SetCameraPositionToThirdPerson()
    {
        // Set the offset and rotation for third-person view
        offset = thirdPersonOffset;
        inFirstPerson = false;
        transform.rotation = thirdPersonRotation;
    }

    // Function to dynamically set the camera position
    private void SetCameraPosition()
    {
        // Set the camera position based on the target and the offset
        transform.position = target.position + offset;

        // Update rotation if in first-person view
        if (inFirstPerson)
        {
            transform.rotation = Quaternion.Euler(0, target.transform.eulerAngles.y, 0);
        }
    }

    // Coroutine for smoothly transitioning the camera to a first-person view
    private IEnumerator SmoothTransitionToFirstPerson()
    {
        // Initialize variables
        float duration = 1f; 
        float elapsedTime = 0f; 

        // Starting rotation and position
        Quaternion startRotation = transform.rotation;
        Vector3 startingOffset = offset;

        // Ending rotation and position for first-person view
        Quaternion endRotation = Quaternion.Euler(0, target.transform.eulerAngles.y, 0);
        Vector3 firstPersonOffset = new Vector3(0, 1.5f, 0);

        // Loop to interpolate between the starting and ending positions and rotations
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            offset = Vector3.Lerp(startingOffset, firstPersonOffset, t);
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Apply final first-person settings
        offset = firstPersonOffset;
        inFirstPerson = true;
    }

    // Coroutine for smoothly transitioning the camera back to a third-person view
    private IEnumerator SmoothTransitionToThirdPerson()
    {
        // Initialize variables
        float duration = 1f; 
        float elapsedTime = 0f; 

        // Starting rotation and position
        Vector3 startingOffset = offset;
        Quaternion startRotation = transform.rotation;

        // Ending rotation and position for third-person view
        Vector3 endOffset = thirdPersonOffset;
        Quaternion endRotation = thirdPersonRotation;

        // Loop to interpolate between the starting and ending positions and rotations
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            offset = Vector3.Lerp(startingOffset, endOffset, t);
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Apply final third-person settings
        offset = endOffset;
        transform.rotation = endRotation;
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
        offset.y = desiredCameraHeight;
    }


    // Function to perform a sphere cast to detect any obstructions between the camera and the player
    private void SphereCastToPlayer()
    {
        // Skip sphere casting if in first-person view
        if (inFirstPerson) { return; }

        // Initialize variables for sphere casting
        RaycastHit hit;
        float radius = 0.002f;
        Vector3 directionToPlayer = target.position - transform.position;
        float maxDistance = Vector3.Distance(target.position, transform.position);

        // For debugging: draw a line from the camera to the player
        Debug.DrawLine(transform.position, target.position, Color.red, 2.0f);

        // Perform the sphere cast
        if (Physics.SphereCast(transform.position, radius, directionToPlayer, out hit, maxDistance, cameraTarget))
        {
            // Check if the sphere cast hit a wall or door trigger
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
            offset.y = Mathf.Lerp(offset.y, thirdPersonOffset.y, Time.deltaTime);
        }
    }
}


//using System.Collections;
//using System.Collections.Generic;
//using System.Net.NetworkInformation;
//using Unity.VisualScripting;
//using UnityEngine;

//public class CameraFollow : MonoBehaviour
//{
//    [System.Serializable]
//    public class Doorway
//    {
//        public Transform doorTrigger;
//        public Transform doorThreshold;
//    }

//    public Transform target;
//    public float smoothSpeed = 0.125f;
//    private Vector3 offset;
//    public Vector3 thirdPersonOffset = new Vector3(0, 3, -5);
//    public Quaternion thirdPersonRotation = Quaternion.Euler(20, 0, 0);
//    //public Vector3 FirstPersonOffest = new Vector3(0, 0, 0);
//    bool inFirstPerson = false;

//    [Serialize] public LayerMask cameraTarget;
//    public List<Doorway> doorways = new List<Doorway> ();
//    private Transform currentDoorThreshhold;

//    private void Start()
//    {
//        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeEntrance += ChangeOffsetToFirstPerson;
//        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeExit += ChangeOffsetToThirdPerson;
//        SetCameraPositionToThirdPerson();
//    }

//    private void Update()
//    {
//        SetCameraPosition();
//        SphereCastToPlayer();
//    }

//    private void ChangeOffsetToFirstPerson()
//    {
//        StartCoroutine(SmoothTransitionToFirstPerson());
//    }

//    private void ChangeOffsetToThirdPerson()
//    {
//        StartCoroutine(SmoothTransitionToThirdPerson());
//    }

//    private void SetCameraPositionToThirdPerson()
//    {
//        offset = thirdPersonOffset;
//        inFirstPerson = false;
//        transform.rotation = Quaternion.Euler(20, 0, 0);
//    }

//    private void SetCameraPosition() 
//    {
//        transform.position = target.position + offset;
//        if (inFirstPerson)
//        {
//            transform.rotation = Quaternion.Euler(0, target.transform.eulerAngles.y, 0);
//        }
//    }


//    private IEnumerator SmoothTransitionToFirstPerson()
//    {
//        float duration = 1f;
//        float elapsedTime = 0f;

//        Quaternion startRotation = transform.rotation;
//        Vector3 startingOffset = offset;

//        Quaternion endRotation = Quaternion.Euler(0, target.transform.eulerAngles.y, 0);
//        Vector3 firstPersonOffset = new Vector3(0, 1.5f, 0);

//        while (elapsedTime < duration)
//        {
//            float t = elapsedTime / duration;
//            offset = Vector3.Lerp(startingOffset, firstPersonOffset, t);
//            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
//            elapsedTime += Time.deltaTime;
//            yield return null;
//        }
//        offset = firstPersonOffset;
//        inFirstPerson = true;  
//    }

//    private IEnumerator SmoothTransitionToThirdPerson()
//    {
//        float duration = 1f;
//        float elapsedTime = 0f;


//        Vector3 startingOffset = offset;
//        Quaternion startRotation = transform.rotation;


//        Vector3 endOffset = thirdPersonOffset;
//        Quaternion endRotation = thirdPersonRotation; 

//        while (elapsedTime < duration)
//        {
//            float t = elapsedTime / duration;
//            offset = Vector3.Lerp(startingOffset, endOffset, t);
//            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
//            elapsedTime += Time.deltaTime;
//            yield return null;
//        }

//        offset = endOffset;
//        transform.rotation = endRotation;
//        inFirstPerson = false;
//    }

//    private void AdjustCameraHeightBasedOnDoorwayPosition()
//    {
//        float distBetweenPlayerAndThresh = Vector3.Distance(target.position, currentDoorThreshhold.position);
//        float maxDoorwayDistance = 3.0f;
//        float t = Mathf.Clamp01(distBetweenPlayerAndThresh / maxDoorwayDistance);

//        float desiredCameraHeight = Mathf.Lerp(thirdPersonOffset.y - 2f, thirdPersonOffset.y, t);
//        offset.y = desiredCameraHeight;
//    }

//    private void SphereCastToPlayer()
//    {
//        if (inFirstPerson) { return ; }


//        RaycastHit hit;
//        float radius = 0.002f;
//        Vector3 directionToPlayer = target.position - transform.position;
//        float maxDistance = Vector3.Distance(target.position, transform.position);

//        Debug.DrawLine(transform.position, target.position, Color.red, 2.0f);

//        if (Physics.SphereCast(transform.position, radius, directionToPlayer, out hit, maxDistance, cameraTarget))
//        {
//            // Check if you hit a wall or door
//            if (hit.collider.CompareTag("CameraDoorTrigger"))
//            {
//                currentDoorThreshhold = doorways.Find(doorway => doorway.doorTrigger == hit.collider.transform).doorThreshold;
//                AdjustCameraHeightBasedOnDoorwayPosition();
//            }
//        }
//        else
//        {
//            offset.y = Mathf.Lerp(offset.y, 3, Time.deltaTime);
//        }
//    }
//}

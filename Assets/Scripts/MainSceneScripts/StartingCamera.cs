using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartingCamera : MonoBehaviour
{
    private Vector3 startingPosition = new Vector3(0, 15.3999996f, 160.699997f);
    private Vector3 endingPosition = new Vector3(0, 12.8f, 34.4f);
    private float lerpDuration = 5.65f;

    private void Start()
    {
        GameManager.instance.gameEvents.OnPlayerHasEnteredMainScene += StartCameraLerp;
    }

    IEnumerator LerpCameraPosition()
    {
        float lerpTime = 0;

        while (lerpTime < lerpDuration)
        {
            lerpTime += Time.deltaTime;
            float lerpProgress = lerpTime / lerpDuration;

            transform.position = Vector3.Lerp(startingPosition, endingPosition, lerpProgress);

            yield return null; 
        }

        transform.position = endingPosition;
        yield return new WaitForSeconds(1f);
        GameManager.instance.gameEvents.CallCameraLerpCompelte();
    }

   private void StartCameraLerp()
   {
        StartCoroutine(LerpCameraPosition());
   }

    private void OnDestroy()
    {
        GameManager.instance.gameEvents.OnPlayerHasEnteredMainScene -= StartCameraLerp;
    }

}

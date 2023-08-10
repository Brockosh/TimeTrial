using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class StartingCamera : MonoBehaviour
{
    private Vector3 startingPosition = new Vector3(0, 15.3999996f, 160.699997f);
    private Vector3 endingPosition = new Vector3(0, 12.8f, 34.4f);
    private float lerpDuration = 7.0f;

    private void Start()
    {
        StartCoroutine(LerpCameraPosition());
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
    }

}

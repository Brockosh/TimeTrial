using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera IntroCamera;
    public Camera PlayerFollowCamera;

    private void Start()
    {
        IntroCamera.enabled = true;
        PlayerFollowCamera.enabled = false;
        GameManager.instance.gameEvents.OnCameraLerpComplete += SwitchCameras;
    }

    private void SwitchCameras()
    {
        IntroCamera.enabled = false;
        PlayerFollowCamera.enabled = true;
    }
}

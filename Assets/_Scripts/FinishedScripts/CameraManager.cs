using UnityEngine;
/// <summary>
/// Class to control switching between cameras in main game scene.
/// </summary>
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

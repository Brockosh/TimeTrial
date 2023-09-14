using UnityEngine;
/// <summary>
/// Class to control disable of thumbstick if not android device.
/// </summary>
public class ThumbStickHolder : MonoBehaviour
{
    private void Awake()
    {
#if UNITY_ANDROID
        // Do nothing, it will remain active
#else
        gameObject.SetActive(false);  
#endif
    }
}

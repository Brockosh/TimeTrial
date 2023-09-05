using UnityEngine;

public class ThumbStickHolder : MonoBehaviour
{
    private void Awake()
    {
#if UNITY_IOS
        // Do nothing, it will remain active
#else
        gameObject.SetActive(false);  
#endif
    }
}

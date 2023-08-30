using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Serialized private float for volume setting
    [SerializeField] private float volume;

    // Singleton instance of AudioManager
    public static AudioManager instance;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Singleton pattern: If no other AudioManager instance exists, use this one and preserve it between scene changes
        if (instance == null)
        {
            instance = this;
            // Don't destroy this GameObject when loading a new scene
            DontDestroyOnLoad(gameObject); 
        }

        // Set the global audio volume to 0.5 by default
        AudioListener.volume = 0.5f;
    }

    // Public method to set the volume
    public void SetVolume(float vol)
    {
        // Set global audio volume
        AudioListener.volume = vol;
    }

    // Public method to get the volume
    public float GetVolume()
    {
        // Return the current volume setting
        return volume;
    }
}

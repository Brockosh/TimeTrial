using UnityEngine;
/// <summary>
/// Class to manage audio for entire game, uses AudioListener for volume control.
/// </summary>
public class AudioManager : MonoBehaviour
{

    [SerializeField] private float volume;
    public static AudioManager instance;


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

    public void SetVolume(float vol)
    {
        // Set global audio volume
        AudioListener.volume = vol;
    }

    public float GetVolume()
    {
        // Return the current volume setting
        return volume;
    }
}

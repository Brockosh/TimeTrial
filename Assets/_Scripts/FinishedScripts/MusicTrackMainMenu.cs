using UnityEngine;
/// <summary>
/// Class to control the music track for the main menu.
/// </summary>
public class MusicTrackMainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;

    void Start()
    {
        musicSource.Play();
    }
}

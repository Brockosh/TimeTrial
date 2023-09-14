using UnityEngine;
/// <summary>
/// Class to control the main music track for the main scene.
/// </summary>
public class MusicTrack : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;

    private void Start()
    {
        PlaySong();
    }

    private void PlaySong()
    {
        musicSource.Play();
    }
}

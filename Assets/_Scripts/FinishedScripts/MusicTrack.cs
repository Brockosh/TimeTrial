using UnityEngine;

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

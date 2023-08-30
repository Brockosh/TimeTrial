using UnityEngine;

public class MusicTrackMainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;

    void Start()
    {
        musicSource.Play();
    }
}

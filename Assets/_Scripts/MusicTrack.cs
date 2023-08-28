using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrack : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;

    private void Start()
    {
        //musicSource.volume = AudioManager.instance.GetVolume();
        PlaySong();
    }

    private void PlaySong()
    {
        musicSource.Play();
        Debug.Log("Song is playing.");
    }

    private void Update()
    {
        Debug.Log(musicSource.volume);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrack : MonoBehaviour
{
    AudioSource musicSource;

    private void Start()
    {
        musicSource = GetComponent<AudioSource>();
        //GameManager.instance.gameEvents.on += PlaySong;
        PlaySong();
    }

    private void PlaySong()
    {
        musicSource.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]private float volume;

    private void Awake()
    {
        if (instance == null)
        {
           instance = this;
           DontDestroyOnLoad(gameObject);
        }

        AudioListener.volume = 0.5f;
    }


    
    private void Update()
    {
        //Debug.Log(GetVolume());
    }

    public void SetVolume(float vol)
    {
        AudioListener.volume = vol;
    }

    public float GetVolume()
    {
        return volume;
    }
}

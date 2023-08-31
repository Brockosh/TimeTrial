using UnityEngine;

public class ButtonClickListener : MonoBehaviour
{
    private AudioSource myAudioSource;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonClickSound()
    {
        myAudioSource.PlayOneShot(myAudioSource.clip);
    }
}

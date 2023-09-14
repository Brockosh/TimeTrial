using UnityEngine;
/// <summary>
/// Class to control audio played when button is clicked.
/// </summary>
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

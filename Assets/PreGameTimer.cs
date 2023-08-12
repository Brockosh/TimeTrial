using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PreGameTimer : MonoBehaviour
{
    public int countdownTime = 3; 
    public TMP_Text countdownText;

    public AudioClip readyClip;
    public AudioClip setClip;
    public AudioClip goClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        GameManager.instance.gameEvents.OnCameraLerpComplete+= StartCoroutineMethod;
        //StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (countdownTime > 0)
        {

            switch (countdownTime)
            {
                case 3:
                    countdownText.text = "Ready";
                    audioSource.clip = readyClip;
                    audioSource.Play();
                    Debug.Log("Ran audio 1");
                    break;
                case 2:
                    countdownText.text = "Set";
                    audioSource.clip = setClip;
                    audioSource.Play();
                    break;
                case 1:
                    countdownText.text = "Go!";
                    audioSource.clip = goClip;
                    audioSource.Play();
                    GameManager.instance.gameEvents.CallPreGameTimerComplete();
                    break;
                default:
                    countdownText.text = countdownTime.ToString();
                    break;
            }

            yield return new WaitForSeconds(1.025f);

            countdownTime--;
        }

        countdownText.text = "";

    }

    private void StartCoroutineMethod()
    {
        StartCoroutine(Countdown());
    }


    void StartCountDown()
    {
        Invoke("StartCoroutineMethod", 2f);
    }
}

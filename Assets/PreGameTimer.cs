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
        //GameManager.instance.gameEvents.OnPlayerHasEnteredMainScene += StartCountdown;
        StartCoroutine(Countdown());
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
                    break;
                default:
                    countdownText.text = countdownTime.ToString();
                    break;
            }

            yield return new WaitForSeconds(1.2f);

            countdownTime--;
        }

        StartGame();
    }

    //private void StartCountdown()
    //{
    //    StartCoroutine(Countdown());
    //}
    void StartGame()
    {
        // Logic to start your game goes here
        countdownText.text = ""; // This hides the countdown text
    }
}

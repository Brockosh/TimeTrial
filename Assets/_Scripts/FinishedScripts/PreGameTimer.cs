using System.Collections;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class PreGameTimer : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private int countdownTime = 3;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private AudioClip readyClip;
    [SerializeField] private AudioClip setClip;
    [SerializeField] private AudioClip goClip;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        GameManager.instance.gameEvents.OnCameraLerpComplete+= StartCoroutineMethod;
    }

    IEnumerator Countdown()
    {
        while (countdownTime > 0)
        {

            switch (countdownTime)
            {
                case 3:
                    countdownText.text = "Ready";
                    audioSource.PlayOneShot(readyClip);
                    break;
                case 2:
                    countdownText.text = "Set";
                    audioSource.PlayOneShot(setClip);
                    break;
                case 1:
                    countdownText.text = "Go!";
                    audioSource.PlayOneShot(goClip);
                    GameManager.instance.gameEvents.CallPreGameTimerComplete();
                    break;
                default:
                    countdownText.text = countdownTime.ToString();
                    break;
            }

            countdownText.rectTransform.DOScale(1.5f, 0.5f).OnComplete(() =>
            {
                countdownText.rectTransform.DOScale(1f, 0.5f);
            });

            yield return new WaitForSeconds(1.025f);

            countdownTime--;
        }
        countdownText.text = "";
    }

    private void StartCoroutineMethod()
    {
        StartCoroutine(Countdown());
    }
}

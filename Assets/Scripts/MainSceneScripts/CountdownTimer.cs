using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//public class CountdownTimer : MonoBehaviour
//{
//    private float countDownTime = 3f;
//    [SerializeField] TextMeshProUGUI countDownText;


//    private void Start()
//    {
//        GameManager.instance.CollisionEvent.OnPlayerCollisionMathsLevel += StartCountDown;
//        GameManager.instance.mathEvents.OnTimeUp += ResetCountDownValue;


//    }


//    private void StartCountDown()
//    {
//        StartCoroutine(Countdown());
//    }

//    private IEnumerator Countdown()
//    {

//        while (countDownTime > 0)
//        {
//            countDownText.text = countDownTime.ToString("0");
//            countDownTime--;
//            yield return new WaitForSeconds(1f);
//        }

//        GameManager.instance.mathEvents.CallTimeUp();
//    }

//    private void ResetCountDownValue()
//    {
//        countDownTime = 3f;
//    }

//}
public class CountdownTimer : MonoBehaviour
{
    private float countDownTime = 3f;
    [SerializeField] TextMeshProUGUI countDownText;

    private Coroutine countdownCoroutine = null;

    private void Start()
    {
        GameManager.instance.CollisionEvent.OnPlayerCollisionMathsLevel += StartCountDown;
        GameManager.instance.mathEvents.OnTimeUp += ResetCountDownValue;
    }

    private void StartCountDown()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }

        countdownCoroutine = StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        countDownTime = 3f;
        while (countDownTime > 0)
        {
            countDownText.text = countDownTime.ToString("0");
            countDownTime--;
            yield return new WaitForSeconds(1f);
        }

        GameManager.instance.mathEvents.CallTimeUp();
    }

    private void ResetCountDownValue()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }

        countDownTime = 3f;
        countDownText.text = countDownTime.ToString("0");

        // Start the countdown again
        StartCountDown();
    }

    private void OnDestroy()
    {
        GameManager.instance.CollisionEvent.OnPlayerCollisionMathsLevel -= StartCountDown;
        GameManager.instance.mathEvents.OnTimeUp -= ResetCountDownValue;
    }
}
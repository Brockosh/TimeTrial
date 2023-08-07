using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class CountdownTimer : MonoBehaviour
{
    private float countDownTime = 3f;
    [SerializeField] TextMeshProUGUI countDownText;
    [SerializeField] Calculator calculator;
    

    private Coroutine countdownCoroutine; 

    public float CountDownTime { get { return countDownTime; } }

    private void Start()
    {
        GameManager.instance.CollisionEvent.OnPlayerCollisionMathsLevel += StartCountDown;
        GameManager.instance.mathEvents.OnTimeUp += ResetCountDownValue;
        //GameManager.instance.mathEvents.OnPlayerCorrectAnswer += MakeTimeTextNull;
        GameManager.instance.mathEvents.OnPlayerCorrectAnswer += ResetCountDownValue;
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
        //countDownTime = 3f;
        while (countDownTime > 0)
        {
            countDownText.text = countDownTime.ToString("0");
            countDownTime--;
            yield return new WaitForSeconds(1f);
        }
        countDownText.text = calculator.CorrectAnswer.ToString("0");
        yield return new WaitForSeconds(1f);
        GameManager.instance.mathEvents.CallTimeUp();

    }

    private void ResetCountDownValue()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }

        countDownTime = 3f;
        StartCountDown();
        Debug.Log("Countdown reset;");
    }

    private void MakeTimeTextNull()
    {
        countDownText.text = null;
    }

    private void OnDestroy()
    {
        GameManager.instance.CollisionEvent.OnPlayerCollisionMathsLevel -= StartCountDown;
        GameManager.instance.mathEvents.OnTimeUp -= ResetCountDownValue;
    }
}
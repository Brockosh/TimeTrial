//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public class Timer : MonoBehaviour
//{

//    public TextMeshProUGUI gameTimer;
//    private float totalTime = 0.0f;
//    private float seconds = 0;
//    private bool isTimerActive;

//    // Start is called before the first frame update
//    void Start()
//    {
//        GameManager.instance.CollisionEvent.OnPlayerCollisionStartLine += ActivateTimer;
//        GameManager.instance.CollisionEvent.OnPlayerCollisionStartLine += DisplayTimer;
//        GameManager.instance.CollisionEvent.OnPlayerCollisionFinishLine += StopTimer;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        UpdateTimer();

//    }

//    private void UpdateTimer()
//    {
//        if (isTimerActive)
//        {
//            seconds += Time.deltaTime;
//            // Update the timer text to show the time with two decimal places
//            //gameTimer.text = $"Time: {seconds.ToString("F2")}";
//        }
//    }

//    private void DisplayTimer()
//    {
//        gameTimer.text = $"Time: {seconds.ToString("F2")}";
//    }

//    private void ActivateTimer()
//    {
//        isTimerActive = true;
//    }

//    private void StopTimer()
//    {
//        isTimerActive = false;
//    }
//}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI gameTimer;
    private float seconds = 0;
    private bool isTimerActive;

    void Start()
    {
        GameManager.instance.CollisionEvent.OnPlayerCollisionStartLine += ActivateTimer;
        GameManager.instance.CollisionEvent.OnPlayerCollisionFinishLine += StopTimer;
    }


    void Update()
    {
        UpdateTimer();
        DisplayTimer();
    }

    private void UpdateTimer()
    {
        if (isTimerActive)
        {
            seconds += Time.deltaTime;
        }
    }

 

    private void DisplayTimer()
    {
        if (isTimerActive)
        {
            int minutes = Mathf.FloorToInt(seconds / 60);
            float remainingSeconds = seconds % 60;

            if (minutes > 0)
            {
                gameTimer.text = $"Time: {minutes} min {remainingSeconds.ToString("0")} sec";
            }
            else
            {
                gameTimer.text = $"Time: {seconds.ToString("F2")}";
            }
        }
    }


    private void ActivateTimer()
    {
        isTimerActive = true;
    }

    private void StopTimer()
    {
        isTimerActive = false;
    }
}
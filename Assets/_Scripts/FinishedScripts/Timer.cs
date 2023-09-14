using TMPro;
using UnityEngine;
/// <summary>
/// Class to control game timer functionality and its format.
/// </summary>
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
        // Check if the timer is active before updating the display
        if (isTimerActive)
        {
            // Convert the total number of seconds to minutes and remaining seconds
            int minutes = Mathf.FloorToInt(seconds / 60);
            float remainingSeconds = seconds % 60;

            // If there are one or more minutes, display time in "minutes and seconds" format
            if (minutes > 0)
            {
                gameTimer.text = $"Time: {minutes} min {remainingSeconds.ToString("0")} sec";
            }
            // If less than a minute, display time in seconds with two decimal places
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
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private int minute;
    private float seconds;

    private void Update()
    {
        seconds += Time.deltaTime;

        if (seconds >= 60)
        {
            seconds = 0;
            minute++;
        }
        
        SetTimerText();
    }

    private void SetTimerText()
    {
        string minuteText = string.Empty;
        string secondText = string.Empty;
        
        if (minute < 10)
        {
            minuteText = "0" + minute;
        }
        else
        {
            minuteText = minute.ToString();
        }

        if (seconds < 10)
        {
            secondText = "0" + (int)seconds;
        }
        else
        {
            secondText = ((int)seconds).ToString();
        }

        timerText.text = minuteText + ":" + secondText;
    }
}

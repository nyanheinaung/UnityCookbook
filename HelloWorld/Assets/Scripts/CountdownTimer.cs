using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CountdownTimer : MonoBehaviour
{
    private Text countdownText;

    public float countdownDuration;
    private float timerStartTime;

    // Start is called before the first frame update
    void Start()
    {
        countdownText = GetComponent<Text>();
        ResetCountdownTimer();
    }

    // Update is called once per frame
    void Update()
    {
        string timerText = "Timer Finished!";
        int timeLeft = (int)TimerSecondsRemaining();
        if (timeLeft > 0)
        {
            timerText = "Seconds Remaining : " + LeadingZero(timeLeft);
        }

        countdownText.text = timerText;
    }

    private void ResetCountdownTimer()
    {
        timerStartTime = Time.time;
    }

    private float TimerSecondsRemaining()
    {
        float timeElapsed = Time.time - timerStartTime;
        
        return countdownDuration - timeElapsed;
    }
    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}

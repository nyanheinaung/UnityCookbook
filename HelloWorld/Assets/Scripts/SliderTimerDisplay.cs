using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimerDisplay : MonoBehaviour
{
    private CountdownTimer2 countdownTimer2;
    private Slider sliderUI;
    public int countdownSeconds = 20;

    // Start is called before the first frame update
    void Start()
    {
        SetUpSlider();
        SetUpTimer();
    }

    private void SetUpTimer()
    {
        countdownTimer2 = GetComponent<CountdownTimer2>();
        countdownTimer2.ResetTimer(countdownSeconds);
    }

    private void SetUpSlider()
    {
        sliderUI = GetComponent<Slider>();
        sliderUI.minValue = 0;
        sliderUI.maxValue = 1;
        sliderUI.wholeNumbers = false;
    }

    // Update is called once per frame
    void Update()
    {
        sliderUI.value = countdownTimer2.GetProportionTimeRemaining();
        print(countdownTimer2.GetProportionTimeRemaining());
    }
}

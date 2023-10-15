﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ClockDigital : MonoBehaviour
{
    private Text textClock;

    // Start is called before the first frame update
    void Start()
    {   //change textClock to public and drag and drop the Text UI oject to that.
        textClock = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DateTime time = DateTime.Now;
        string hour = LeadingZero(time.Hour);
        string minute = LeadingZero(time.Minute);
        string second = LeadingZero(time.Second);

        textClock.text = hour + ":" + minute + ":" + second;
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}

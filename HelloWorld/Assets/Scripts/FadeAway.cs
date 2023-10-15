using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAway : MonoBehaviour
{
    private CountdownTimer2 countdownTimer2;
    private Text textUI;
    public int fadeDuration;
    private bool fade = false;

    // Start is called before the first frame update
    void Start()
    {
        countdownTimer2 = GetComponent<CountdownTimer2>();
        textUI = GetComponent<Text>();
        StartFading(fadeDuration);
    }

    // Update is called once per frame
    void Update()
    {
        if(fade)
        {
            float AlphaRemaining = countdownTimer2.GetProportionTimeRemaining();
            print(AlphaRemaining);
            Color c = textUI.material.color;
            c.a = AlphaRemaining;
            

            if(AlphaRemaining < 0.01)
            {
                fade = false;
                c.a = 0;
            }

            textUI.material.color = c;
        }
    }

    private void StartFading(int timerTotal)
    {
        countdownTimer2.ResetTimer(timerTotal);
        fade = true;
    }
}

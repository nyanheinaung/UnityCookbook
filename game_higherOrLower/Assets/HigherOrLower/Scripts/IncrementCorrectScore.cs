using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementCorrectScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int newScoreCorrect = 1 + PlayerPrefs.GetInt("scoreCorrect");
        PlayerPrefs.SetInt("scoreCorrect", newScoreCorrect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

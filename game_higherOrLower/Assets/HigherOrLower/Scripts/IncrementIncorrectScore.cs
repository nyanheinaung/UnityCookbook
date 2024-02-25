using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementIncorrectScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int newScoreIncorrect = 1 + PlayerPrefs.GetInt("scoreIncorrect");
        PlayerPrefs.SetInt("scoreIncorrect", newScoreIncorrect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

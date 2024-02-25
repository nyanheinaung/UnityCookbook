using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text scoreText = GetComponent<Text>();
        int scoreCorrect = PlayerPrefs.GetInt("scoreCorrect");
        int scoreIncorrect = PlayerPrefs.GetInt("scoreIncorrect");
        int totalAttempts = scoreCorrect + scoreIncorrect;
        string scoreMessage = "";
        if (totalAttempts > 0)
        {
            scoreMessage = "Score:";
            scoreMessage += scoreCorrect + "/" + totalAttempts;
        }
        
        scoreText.text = scoreMessage;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

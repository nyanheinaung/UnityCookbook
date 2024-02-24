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
        int totalAttempts = Player.scoreCorrect + Player.scoreIncorrect;
        string scoreMessage = "";
        if (totalAttempts > 0)
        {
            scoreMessage = "Score:";
            scoreMessage += Player.scoreCorrect + "/" + totalAttempts;
        }
        
        scoreText.text = scoreMessage;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

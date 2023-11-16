using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayNStop : MonoBehaviour
{
    public static bool playing = false;

    public Button recordButton;
        
    private RecordNFinish recordNFinishRef;

    private Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        //Get button reference
        playButton = GetComponent<Button>();
        //Initialize Text to Play
        ChangeButtonText("PLAY");
        //Get a reference to RecordNFinish script
        recordNFinishRef = recordButton.GetComponent<RecordNFinish>();
    }
    
    //When button clicked, change text and do relavant task, if valid
    public void Clicked()
    {
        //Only works if not recording
        if (!RecordNFinish.recording)
        {
            //Change play or stop
            playing = !playing;

            if (playing)
            {
                ChangeButtonText("STOP");
                PlayRecord();
            }
            else
            {
                ChangeButtonText("PLAY");
                StopRecord();
            }
        }    
    }

    //Since the KeyList is placed and private, actual playing take places in RecordNFinish
    void PlayRecord()
    {
        recordNFinishRef.PlayRecord();
    }

    //Same as above
    void StopRecord()
    {
        recordNFinishRef.StopPlayingRecord();
    }

    //Text change method, should change to a seperate script??
    void ChangeButtonText(string buttonText)
    {
        playButton.GetComponentInChildren<Text>().text = buttonText;
    }
}

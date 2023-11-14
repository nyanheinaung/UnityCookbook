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

    public void Clicked()
    {
        if (!RecordNFinish.recording)
        {
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

    void PlayRecord()
    {
        //print("Start playing");
        recordNFinishRef.PlayRecord();
    }

    void StopRecord()
    {
        //print("Stop playing");
        recordNFinishRef.StopPlayingRecord();
    }

    void ChangeButtonText(string buttonText)
    {
        playButton.GetComponentInChildren<Text>().text = buttonText;
    }

    // Start is called before the first frame update
    void Start()
    {
        playButton = GetComponent<Button>();
        ChangeButtonText("PLAY");
        recordNFinishRef = recordButton.GetComponent<RecordNFinish>();
    }

}

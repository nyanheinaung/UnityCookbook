using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordNFinish : MonoBehaviour
{
    public static bool recording = false;

    private static List<Key> keyRecord = new List<Key>();

    private Button recordButton;

    private Key currentKey;

    private PlayNStop playNStopRef;

    public Button playButton;

    public float interval = 1.0f;

    private bool stopIsPressed = false;

    private Coroutine waitCoroutine;

    private void Start()
    {
        //Button reference
        recordButton = GetComponent<Button>();
        //Initialize Text as Record
        ChangeButtonText("RECORD");
        //Get reference to PlayNStop script
        playNStopRef = playButton.GetComponent<PlayNStop>();
    }

     //When button clicked, change text and do relavant task, if valid
    public void Clicked()
    {
        //If not playing, start recording
        if (!PlayNStop.playing)
        {
            //If there is FinishRecording method, this should take place in both there and StartRecording method
            recording = !recording;

            if (recording)
            {
                ChangeButtonText("FINISH");
                StartRecording();
            }
            else
            {
                ChangeButtonText("RECORD");
                
            }
        }
    }

    //Text change method, should change to a seperate script??
    void ChangeButtonText(string buttonText)
    {
        recordButton.GetComponentInChildren<Text>().text = buttonText;
    }

    //If record is in progress, any key pressed will be added to the keyList
    public void AddKey(Key addedKey)
    {      
        keyRecord.Add(addedKey);
    }

    //Empty previous record when new recording starts
    public void StartRecording()
    {
        EmptyRecord();
    }

    public void EmptyRecord()
    {
        keyRecord.Clear();
    }
    
    public void PlayRecord()
    {    
        //Loop breaker for when Stop is pressed while playing
        stopIsPressed = false;
        waitCoroutine = StartCoroutine(WaitAndContinue());
    }

    public void StopPlayingRecord()
    {
        //Check whether there is a valid record. if not, there will be null exception
        if (keyRecord.Count > 0)
        {
            stopIsPressed = true;
            currentKey.StopKey();
            if(waitCoroutine!=null)
            {
                StopCoroutine(waitCoroutine);
            }   
        }
    }

    IEnumerator WaitAndContinue()
    {
        if (keyRecord.Count > 0)
        {
            foreach (Key key in keyRecord)
            {
                currentKey = key;
                key.PlayKey();
                yield return new WaitForSeconds(interval);

                if (stopIsPressed)
                {
                    break;
                }
            }

        }
        else
        {
            print("No key recorded!");
        }

        //If the record finished playing, change back to Play state by
        //automatically clicking it once.
        playNStopRef.Clicked();
    }
}

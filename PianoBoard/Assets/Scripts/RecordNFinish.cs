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
        recordButton = GetComponent<Button>();
        ChangeButtonText("RECORD");
        playNStopRef = playButton.GetComponent<PlayNStop>();
    }

    public void Clicked()
    {
        //If not playing, start recording
        if (!PlayNStop.playing)
        {
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

    void ChangeButtonText(string buttonText)
    {
        recordButton.GetComponentInChildren<Text>().text = buttonText;
    }

    public void AddKey(Key addedKey)
    {
        
        keyRecord.Add(addedKey);
    }

    public void StartRecording()
    {
        EmptyRecord();
        //print("Recording Started");
    }

    public void EmptyRecord()
    {
        keyRecord.Clear();
    }

    public void PlayRecord()
    {
        stopIsPressed = false;

        waitCoroutine = StartCoroutine(WaitAndContinue());

        //playNStopRef.Clicked();
        
    }

    public void StopPlayingRecord()
    {
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
                //key.LightUp();
                key.PlayKey();

                //key.LightOff();
                yield return new WaitForSeconds(interval);
                //waitCoroutine = 
                //StartCoroutine(WaitAndContinue());

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

        playNStopRef.Clicked();
    }
}

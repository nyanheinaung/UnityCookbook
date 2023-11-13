using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordNFinish : MonoBehaviour
{
    public static bool recording = false;
    List<Key> keyRecord = new List<Key>();
    public Text buttonText;

    private void OnMouseDown()
    {
        //If not playing, start recording
        if (!PlayNStop.playing)
        {
            recording = !recording;
            ChangeButtonText();
        }
    }

    void ChangeButtonText()
    {

    }

    public void AddKey(Key addedKey)
    {
        keyRecord.Add(addedKey);
    }

    public void EmptyRecord()
    {

    }



}

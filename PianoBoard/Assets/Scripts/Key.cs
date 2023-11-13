using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private Renderer keyRenderer;
    //private Color initialColor;
    //private static PlayNStop playNStop;

    private AudioSource keySound;
    private RecordNFinish recordNFinishRef;
    

    private void Start()
    {
        keyRenderer = GetComponent<Renderer>();
        keyRenderer.material.SetColor("_Color", Color.white);

        keySound = GetComponent<AudioSource>();

    }

    public void PlayKey()
    {
        keySound.Play();
    }

    void StopKey()
    {

    }

    void OnMouseDown()
    {
        //Only works when recording is not playing
        if (!PlayNStop.playing)
        {
            keyRenderer.material.SetColor("_Color", Color.red);
            PlayKey();

            //If recording is true, add key to list
            if (RecordNFinish.recording)
            {
                recordNFinishRef.AddKey(this);
            }
        }

    }

    void OnMouseUp()
    {
        //if (!playNStop.isPlaying)
        //{
            keyRenderer.material.SetColor("_Color", Color.white);
        //}

    }

}

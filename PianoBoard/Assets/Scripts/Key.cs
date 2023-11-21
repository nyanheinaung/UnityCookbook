using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    private Renderer keyRenderer;

    private AudioSource keySound;

    private RecordNFinish recordNFinishRef;

    public Button recordButton;

    private Coroutine waitCoroutine;

    public float keySoundInterval = 0.1f;

    private void Start()
    {   //Get access to change material color
        keyRenderer = GetComponent<Renderer>();
        //Set initial color to white
        keyRenderer.material.SetColor("_Color", Color.white);
        //Get attached sound file
        keySound = GetComponent<AudioSource>();
        //Get reference of RecordNFinish script via Button (Might not need to access it this way)
        recordNFinishRef = recordButton.GetComponent<RecordNFinish>();
    }

    //Play the key. Awkward with only starting Coroutine
    public void PlayKey()
    {
        //Store reference to currently going coroutine
        waitCoroutine = StartCoroutine(WaitForSound());
    }

    //Stop the currently playing key, if any, and also coroutine
    public void StopKey()
    {
        keySound.Stop();
        if (waitCoroutine != null)
        {
            StopCoroutine(waitCoroutine);
        }
    }

    void OnMouseDown()
    {
        //Only works when recording is not playing
        if (!PlayNStop.playing)
        {

            //If recording is true, add key to list
            if (RecordNFinish.recording)
            {
                recordNFinishRef.AddKey(this);
            }

            //This should be PlayKey()
            StartCoroutine(WaitForSound());
            

        }

    }

    //Change key color to red
    public void LightUp()
    {
        keyRenderer.material.SetColor("_Color", Color.red);
    }

    //Change key color to white
    public void LightOff()
    {
        keyRenderer.material.SetColor("_Color", Color.white);
    }

    //Initially Wait till key finished playing
    //But the red light is so long, just blink 0.1 sec regardless of sound finished playing
    IEnumerator WaitForSound()
    {
        //If you want to wait the script before going down, write all in this setup
        LightUp();
        keySound.Play();
        yield return new WaitForSeconds(keySoundInterval);
        LightOff();
    }
}

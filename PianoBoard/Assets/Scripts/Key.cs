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

    private void Start()
    {
        keyRenderer = GetComponent<Renderer>();
        keyRenderer.material.SetColor("_Color", Color.white);
        keySound = GetComponent<AudioSource>();
        recordNFinishRef = recordButton.GetComponent<RecordNFinish>();
    }

    public void PlayKey()
    {
        keySound.Play();
        //waitCoroutine =
        StartCoroutine(WaitForSound());
    }

    public void StopKey()
    {
        keySound.Stop();
        //StopCoroutine(waitCoroutine);
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

            LightUp();
            PlayKey();
            LightOff();
        }

    }

    public void LightUp()
    {
        keyRenderer.material.SetColor("_Color", Color.red);
    }

    public void LightOff()
    {
        keyRenderer.material.SetColor("_Color", Color.white);
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitWhile(() => keySound.isPlaying);
    }
}

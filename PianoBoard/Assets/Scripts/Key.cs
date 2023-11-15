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
    {
        keyRenderer = GetComponent<Renderer>();
        keyRenderer.material.SetColor("_Color", Color.white);
        keySound = GetComponent<AudioSource>();
        recordNFinishRef = recordButton.GetComponent<RecordNFinish>();
    }

    public void PlayKey()
    {
        waitCoroutine = StartCoroutine(WaitForSound());
    }

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

            StartCoroutine(WaitForSound());
            

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
        LightUp();
        keySound.Play();
        yield return new WaitForSeconds(keySoundInterval);
        LightOff();
    }
}

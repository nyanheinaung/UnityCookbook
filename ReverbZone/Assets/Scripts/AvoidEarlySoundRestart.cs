using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvoidEarlySoundRestart : MonoBehaviour
{
    public AudioSource audioSource;
    public Text message;


    // Update is called once per frame
    void Update()
    {
        string statusMessage = "Play Sound";
        if (audioSource.isPlaying)
        {
            statusMessage = "(Sound Playing)";
        }
        message.text = statusMessage;
    }

    // button click handler
    public void PlaySoundEffectIfNotPlaying()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class PlayVideo : MonoBehaviour
{
    public bool loop = true;
    public bool playFromStart = true;
    public MovieTexture video;
    public AudioClip audioClip;
    private AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        if (!video)
            video = GetComponent<Renderer>().material.mainTexture as
            MovieTexture;
        if (!audioClip)
            audioClip = audio.clip;
        video.Stop();
        audio.Stop();
        video.loop = loop;
        audio.loop = loop;
        if (playFromStart)
            ControlMovie();
    }
    void OnMouseUp()
    {
        ControlMovie();
    }

public void ControlMovie()
    {
        if (video.isPlaying)
        {
            video.Pause();
            audio.Pause();
        }
        else
        {
            video.Play();
            audio.Play();
        }
    }
}
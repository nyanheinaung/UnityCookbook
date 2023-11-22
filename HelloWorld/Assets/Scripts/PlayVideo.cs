using UnityEngine;
using System.Collections;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public bool loop = true;
    public bool playFromStart = true;
 
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.isLooping = loop;
       
        if (playFromStart)
            ControlMovie();
    }
    void OnMouseUp()
    {
        ControlMovie();
    }

public void ControlMovie()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
    }
}
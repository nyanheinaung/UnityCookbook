using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ReadDefaultResources : MonoBehaviour
{
    public string fileName = "externalTexture";
    private Texture2D externalImage;

    public string textFileName = "textFileName";
    private string textFileContents;

    public string audioFileName = "soundtrack";
    private AudioClip audioFile;

    // Start is called before the first frame update
    void Start()
    {
        externalImage = (Texture2D)Resources.Load(fileName);
        Renderer myRenderer = GetComponent<Renderer>();
        myRenderer.material.SetTexture("_MainTex", externalImage);

        TextAsset textAsset = (TextAsset)Resources.Load(textFileName);
        textFileContents = textAsset.text;
        Debug.Log(textFileContents);

        AudioSource audioSource = GetComponent<AudioSource>();
        audioFile = (AudioClip)Resources.Load(audioFileName);
        audioSource.clip = audioFile;
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

    }

}

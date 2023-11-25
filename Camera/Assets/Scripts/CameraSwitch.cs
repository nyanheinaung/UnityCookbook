using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera[] cameras;
    public string[] shortcuts;

    public bool enableAudioListener = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            for(int i=0; i < cameras.Length; i++)
            {
                if (Input.GetKeyDown(shortcuts[i]))
                {
                    SwitchCamera(i);
                    print(shortcuts[i]);
                }
            }
        }
    }

    void SwitchCamera(int indexToSelect)
    {
        for(int i = 0; i < cameras.Length; i++)
        {
            bool cameraActive = (i == indexToSelect);
            cameras[i].GetComponent<Camera>().enabled = cameraActive;

            if (enableAudioListener)
            {
                cameras[i].GetComponent<AudioListener>().enabled = cameraActive;
            }
        }
    }
}

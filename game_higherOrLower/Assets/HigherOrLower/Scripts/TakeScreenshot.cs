using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class TakeScreenshot : MonoBehaviour
{
    public string prefix = "Screenshot";
    public enum method{
        captureScreenshotPng, ReadPixelsPng, ReadPixelsJpg
    };
    public method captMethod = method.captureScreenshotPng;
    public int captureScreenshotScale = 1;

    [Range(0, 100)]
    public int jpgQuality = 75;

    private Texture2D texture;
    private int sw;
    private int sh;
    private Rect sRect;
    string date;

    // Start is called before the first frame update
    void Start()
    {
        sw = Screen.width;
        sh = Screen.height;
        sRect = new Rect(0, 0, sw, sh);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeShot();
        }
    }

    private void TakeShot()
    {
        date = System.DateTime.Now.ToString("_d-MM-yyyy-HH-mm-ss-f");

        if(captMethod == method.captureScreenshotPng)
        {
            ScreenCapture.CaptureScreenshot(prefix + date + ".png", captureScreenshotScale);
        }
        else
        {
            StartCoroutine(ReadPixels());
        }
    }

    IEnumerator ReadPixels()
    {
        yield return new WaitForEndOfFrame();

        byte[] bytes;
        texture = new Texture2D(sw, sh, TextureFormat.RGB24, false);
        texture.ReadPixels(sRect, 0, 0);
        texture.Apply();

        if (captMethod == method.ReadPixelsJpg)
        {
            bytes = texture.EncodeToJPG(jpgQuality);
            WriteByteToFile(bytes, ".jpg");
        }
        else if (captMethod == method.ReadPixelsPng)
        {
            bytes = texture.EncodeToPNG();
            WriteByteToFile(bytes, ".png");
        }
    }

    private void WriteByteToFile(byte[] bytes, string format)
    {
        Destroy(texture);
        File.WriteAllBytes(Application.dataPath + "/../" + prefix + date + format, bytes);

    }

}

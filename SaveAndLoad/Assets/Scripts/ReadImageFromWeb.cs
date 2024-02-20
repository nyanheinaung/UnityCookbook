using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadImageFromWeb : MonoBehaviour
{
    public string url = "www.ascii-art.de/ascii/ab/badger.txt";

    IEnumerator Start()
    {
        /*WWW www = new WWW(url);
        yield return www;
        Texture2D texture = www.texture;
        GetComponent<RawImage>().texture = texture;*/

        Text textUI = GetComponent<Text>();
        textUI.text = "(Loading file...)";
        WWW www = new WWW(url);
        yield return www;
        string textFileContents = www.text;
        Debug.Log(textFileContents);

        textUI.text = textFileContents;

    }

}

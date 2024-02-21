using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ReadImageFromWeb : MonoBehaviour
{
    public string url = "http://www.ascii-art.de/ascii/ab/badger.txt";

/*    void Start()
    {
        StartCoroutine(MakeWebRequest());
    }*/

 /*   IEnumerator MakeWebRequest()
    {

        Text textUI = GetComponent<Text>();
        textUI.text = "(Loading file...)";
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Debug.LogError($"Error : {www.error}");
            }
            else
            {
                string textFileContents = www.downloadHandler.text;
                Debug.Log(textFileContents);
                textUI.text = textFileContents;
            }

        } 
    }*/

    IEnumerator Start()
    {
        Text textUI = GetComponent<Text>();
        textUI.text = "(Loading file...)";
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
        string textFileContents = www.downloadHandler.text;
        Debug.Log(textFileContents);
        textUI.text = textFileContents;
    }
}

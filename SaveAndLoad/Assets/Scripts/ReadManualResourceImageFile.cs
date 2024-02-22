using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;

public class ReadManualResourceImageFile : MonoBehaviour
{
    private string fileName = "externalTexture.jpg";
    private string url;
    private Texture2D externalImage;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        url = "file:" + Application.dataPath;
        url = Path.Combine(url, "Resources");
        url = Path.Combine(url, fileName);

        UnityWebRequest uwr = UnityWebRequest.Get(url);

        yield return uwr.SendWebRequest();

        Texture2D texture = uwr.downloadHandler.data;
        GetComponent<Image>().sprite = TextureToSprite(texture);
    }

    private Sprite TextureToSprite(Texture2D texture)
    {
        Rect rect = new Rect(0, 0, texture.width, texture.height);
        Vector2 pivot = new Vector2(0.5f, 0.5f);
        Sprite sprite = Sprite.Create(texture, rect, pivot);
        return sprite;
    }
}

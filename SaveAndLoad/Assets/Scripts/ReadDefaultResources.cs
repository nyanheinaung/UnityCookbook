using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadDefaultResources : MonoBehaviour
{
    public string fileName = "externalTexture";
    private Texture2D externalImage;

    // Start is called before the first frame update
    void Start()
    {
        externalImage = (Texture2D)Resources.Load(fileName);
        Renderer myRenderer = GetComponent<Renderer>();
        myRenderer.material.SetTexture("_MainTex", externalImage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

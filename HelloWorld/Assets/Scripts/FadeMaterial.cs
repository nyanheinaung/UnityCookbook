using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMaterial : MonoBehaviour
{
    public float fadeDuration = 1.0f;
    public bool useMaterialAlpha = false;
    public float alphaStart = 1.0f;
    public float alphaEnd = 0.0f;
    public bool destroyInvisibleObject = true;
    private bool isFading = false;
    private float alphaDiff;
    private float startTime;
    private Renderer rend;
    private Color fadeColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        fadeColor = rend.material.color;

        if (!useMaterialAlpha)
        {
            fadeColor.a = alphaStart;
        }
        else
        {
            alphaStart = fadeColor.a;
        }
        rend.material.color = fadeColor;
        alphaDiff = alphaStart - alphaEnd;
    }
    void Update()
    {
        if (isFading)
        {
            var elapsedTime = Time.time - startTime;
            if (elapsedTime <= fadeDuration)
            {
                var fadeProgress = elapsedTime / fadeDuration;
                var alphaChange = fadeProgress * alphaDiff;
                fadeColor.a = alphaStart - alphaChange;
                rend.material.color = fadeColor;
            }
            else
            {
                fadeColor.a = alphaEnd;
                rend.material.color = fadeColor;
                if (destroyInvisibleObject)
                    Destroy(gameObject);
                
                isFading = false;
            }
        }
    }
    void OnMouseUp()
    {
        FadeAlpha();
    }
    public void FadeAlpha()
    {
        isFading = true;
        startTime = Time.time;
    }
}
            

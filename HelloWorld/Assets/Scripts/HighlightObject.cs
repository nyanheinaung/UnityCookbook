using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    private Color initialColor;
    public bool noEmissionAtStart = true;
    public Color highlightColor = Color.red;
    public Color mousedownColor = Color.green;

    private bool mouseOn = false;
    private Renderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        if (noEmissionAtStart)
        {
            initialColor = Color.black;
        }
        else
        {
            initialColor = myRenderer.material.GetColor("_EmissionColor");
        }
    }

    private void OnMouseEnter()
    {
        mouseOn = true;
        myRenderer.material.SetColor("_EmissionColor", highlightColor);
    }

    private void OnMouseExit()
    {
        mouseOn = false;
        myRenderer.material.SetColor("_EmissionColor", initialColor);
    }

    private void OnMouseDown()
    {
        myRenderer.material.SetColor("_EmissionColor", mousedownColor);
    }

    private void OnMouseUp()
    {
        if (mouseOn)
        {
            myRenderer.material.SetColor("_EmissionColor", highlightColor);
        }
        else
        {
            myRenderer.material.SetColor("_EmissionColor", initialColor);
        }

    }
}

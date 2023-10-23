using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursorPointer : MonoBehaviour
{
    public Texture2D cursorTexture2D;
    public Texture2D defaultCursorTexture;

    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotspot = Vector2.zero;

    private void Start()
    {
        OnMouseExit();    
    }

    public void OnMouseEnter()
    {
        SetCustomCursor(cursorTexture2D);
    }

    public void OnMouseExit()
    {
        SetCustomCursor(defaultCursorTexture);
    }

    private void SetCustomCursor(Texture2D curText)
    {
        Cursor.SetCursor(curText, hotspot, cursorMode);
    }
}

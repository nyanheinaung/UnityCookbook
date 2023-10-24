using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayChangeTextContent : MonoBehaviour
{
    private InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<InputField>();
    }

    public void PrintNewValue()
    {
        string msg = "New content = ' " + inputField.text + "'";
        print(msg);
    }



}

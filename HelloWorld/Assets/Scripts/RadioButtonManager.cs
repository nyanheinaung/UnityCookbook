using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioButtonManager : MonoBehaviour
{
    static Toggle currentDifficulty;
    public string initialDifficulty = "Easy";
    // Start is called before the first frame update
    void Start()
    {
        if(!currentDifficulty)
        {
            currentDifficulty = GameObject.FindGameObjectWithTag(initialDifficulty).GetComponent<Toggle>();
            currentDifficulty.isOn = true;
        }
        
    }

    public void PrintNewGroupValue(Toggle sender)
    {
        if (!sender.CompareTag(currentDifficulty.tag))
        {
            currentDifficulty.isOn = false;
            print("Difficulty changed to : " + sender.tag);
            currentDifficulty = sender;
        }
    }

     // Update is called once per frame
    void Update()
    {
        
    }
}

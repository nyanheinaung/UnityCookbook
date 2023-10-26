using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ToggleGroupManager : MonoBehaviour
{
    ToggleGroup toggleGroup;
    // Start is called before the first frame update
    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
    }

    public void Submit()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        print(toggle.GetComponentInChildren<Text>().text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(WaitForSound());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForSound()
    {
        print("Start");

        yield return new WaitForSeconds(3.0f);

        print("End");
    }
}

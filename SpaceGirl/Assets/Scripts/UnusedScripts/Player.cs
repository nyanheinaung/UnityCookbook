using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text starText;
    private bool carryingStar = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateStartText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Star"))
        {

            carryingStar = true;
            UpdateStartText();
            Destroy(collision.gameObject);
        }
    }
    private void UpdateStartText()
    {
        string starMessage = "no star :-(";
        if (carryingStar) starMessage = "Carrying star :-)";
        starText.text = starMessage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

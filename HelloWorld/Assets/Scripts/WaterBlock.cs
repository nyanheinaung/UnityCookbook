using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBlock : MonoBehaviour
{
    private Animator animatorController;

    // Start is called before the first frame update
    void Start()
    {
        animatorController = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animatorController.SetTrigger("Fall");
            
        }
    }
}

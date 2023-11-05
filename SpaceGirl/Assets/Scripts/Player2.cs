using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private PlayerInventoryModel playerInventoryModel;

    // Start is called before the first frame update
    void Start()
    {
        playerInventoryModel = GetComponent<PlayerInventoryModel>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Star"))
        {
            playerInventoryModel.AddStar();
            Destroy(collision.gameObject);
        }    
    }

}

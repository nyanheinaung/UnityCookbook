using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PlayerInventoryDisplay playerInventoryDisplay;
    //private bool carryingStar = false;

    private int starCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
        playerInventoryDisplay.OnChangeCarryingStar(starCount);
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Star"))
        {
            //carryingStar = true;
            starCount++;
            playerInventoryDisplay.OnChangeCarryingStar(starCount);
            Destroy(hit.gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PlayerInventoryDisplay playerInventoryDisplay;
    //private bool carryingStar = false;

    private List<PickUp> inventory = new List<PickUp>();

    private int starCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
        playerInventoryDisplay.OnChangeCarryingStar(starCount);
        playerInventoryDisplay.OnChangeInventory(inventory);
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

        if (hit.CompareTag("PickUp"))
        {
            PickUp item = hit.GetComponent<PickUp>();
            inventory.Add(item);
            playerInventoryDisplay.OnChangeInventory(inventory);
            Destroy(hit.gameObject);
        }
    }

}

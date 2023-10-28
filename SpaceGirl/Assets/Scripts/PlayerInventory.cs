using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PlayerInventoryDisplay playerInventoryDisplay;
    private bool carryingStar = false;

    // Start is called before the first frame update
    void Start()
    {
        playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
        playerInventoryDisplay.OnChangeCarryingStar(carryingStar);
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Star"))
        {
            carryingStar = true;
            playerInventoryDisplay.OnChangeCarryingStar(carryingStar);
            Destroy(hit.gameObject);
        }
    }

}

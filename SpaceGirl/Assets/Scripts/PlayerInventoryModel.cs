using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryModel : MonoBehaviour
{
    private int starTotal = 0;
    private PlayerInventoryDisplay playerInventoryDisplay;

    // Start is called before the first frame update
    void Start()
    {
        playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
        playerInventoryDisplay.OnChangeStarTotal(starTotal);
    }

    public void AddStar()
    {
        starTotal++;
        playerInventoryDisplay.OnChangeStarTotal(starTotal);
    }
}

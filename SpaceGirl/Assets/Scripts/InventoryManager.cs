using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private PlayerInventoryDisplay playerInventoryDisplay;
    private Dictionary<PickUp.PickUpType, int> items = new Dictionary<PickUp.PickUpType, int>();

    // Start is called before the first frame update
    void Start()
    {
        playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
        playerInventoryDisplay.OnChangeInventory(items);
    }



    public void Add(PickUp pickup)
    {
        PickUp.PickUpType type = pickup.type;
        
	//Does this value necessary?
	//Yes. It is necessary for receiving "out" value parameter from TryGetValue Method
	//associated with Dictionary 
	int oldTotal = 0;
        
	//If you want to delete the previous line, you need to create a new int in the TryGetValue Method
	//like this TryGetValue(type, out int oldTotal)
	if(items.TryGetValue(type, out oldTotal))
        {
            items[type] = oldTotal + 1;
        }
        else
        {
            items.Add(type, 1);
        }
        playerInventoryDisplay.OnChangeInventory(items);
    }
}

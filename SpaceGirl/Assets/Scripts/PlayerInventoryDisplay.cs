using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryDisplay : MonoBehaviour
{
    //public Text starText;
    public Text inventoryText;
    private string newInventoryText;

    //public Image[] starPlaceHolders;
    //public Sprite carryStarImage;
    //public Sprite noStarImage;

    //public Image allStarx4;
    
/*    public void OnChangeCarryingStar(int starCount)
    {
        int newWidth = 100 * starCount;
        allStarx4.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidth);

        for(int i = 0; i < starPlaceHolders.Length; i++)
        {
            if (i < starCount)
            {
                starPlaceHolders[i].sprite = carryStarImage;
            }
            else
            {
                starPlaceHolders[i].sprite = noStarImage;
            }
        }
        
            string starMessage = "Stars = " + starCount;
            starText.text = starMessage;
               
    }*/

    public void OnChangeInventory(Dictionary<PickUp.PickUpType, int> inventory)
    {
     /*   inventory.Sort(
            delegate(PickUp p1, PickUp p2)
            {
                return p1.description.CompareTo(p2.description);
            }
        );*/

        inventoryText.text = "";
        newInventoryText = "Items in Inventory : ";

        int numItem = inventory.Count;

        print(numItem);

        foreach(var item in inventory)
        {
            int itemTotal = item.Value;
            string description = item.Key.ToString();
            newInventoryText += " [ " + description + itemTotal + " ]";
        }

        if(numItem < 1)
        {
            newInventoryText = "Empty Inventory";
        }

        inventoryText.text = newInventoryText;
    }

    const int NUM_INVNETORY_SLOTS = 10;
    public PickUpUI[] slots = new PickUpUI[NUM_INVNETORY_SLOTS];

    public void OnChangeStarTotal(int starTotal)
    {
        for(int i = 0; i<NUM_INVNETORY_SLOTS; i++)
        {
            PickUpUI slot = slots[i];
            if (i < starTotal)
            {
                slot.DisplayYellow();
            }
            else
            {
                slot.DisplayGrey();
            }
        }
    }

}

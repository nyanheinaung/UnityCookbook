using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryDisplay : MonoBehaviour
{
    public Text starText;
    public Text inventoryText;

    public Image[] starPlaceHolders;
    public Sprite carryStarImage;
    public Sprite noStarImage;

    public Image allStarx4;
    
    public void OnChangeCarryingStar(int starCount)
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
               
    }

    public void OnChangeInventory(List<PickUp> inventory)
    {
        inventory.Sort(
            delegate(PickUp p1, PickUp p2)
            {
                return p1.description.CompareTo(p2.description);
            }
        );

        inventoryText.text = "";
        string inventoryList = "Items in Inventory : ";
        int numItem = inventory.Count;
        print(numItem);
        for(int i = 0; i<numItem; i++)
        {
            string description = inventory[i].description;
            inventoryList += " [ " + description + " ]";
        }

        if(numItem < 1)
        {
            inventoryList = "Empty Inventory";
        }

        inventoryText.text = inventoryList;
    }

}

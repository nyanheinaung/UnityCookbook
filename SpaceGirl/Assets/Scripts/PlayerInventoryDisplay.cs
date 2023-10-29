using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryDisplay : MonoBehaviour
{
    public Text starText;

    public Image[] starPlaceHolders;
    public Sprite carryStarImage;
    public Sprite noStarImage;
    
    public void OnChangeCarryingStar(int starCount)
    {
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

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryDisplay : MonoBehaviour
{
    public Text starText;

    public void OnChangeCarryingStar(bool carryingStar)
    {
        string starMessage = "no star :-(";
        if (carryingStar) starMessage = "Carrying star :-)";
        starText.text = starMessage;
    }

}

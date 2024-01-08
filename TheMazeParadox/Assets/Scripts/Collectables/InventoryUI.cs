using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public static TextMeshProUGUI diamondText;
    public  bool flag = true;
    void Start()
    {
        diamondText =  GetComponent<TextMeshProUGUI>();
        if(flag == true)
        {
            UpdateDiamondText();
            flag = false;
        }
    }
    public static void UpdateDiamondText()
    {
        diamondText.text = PlayerInventory.numberOfDiamonds.ToString();
    }
    public void UpdateDiamondText(PlayerInventory playerInventory)
    {
        diamondText.text = PlayerInventory.numberOfDiamonds.ToString();
    }
}

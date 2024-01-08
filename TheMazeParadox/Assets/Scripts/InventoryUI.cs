using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public  TextMeshProUGUI diamondText;
    private bool flag = true;
    void Start()
    {
        diamondText =  GetComponent<TextMeshProUGUI>();
        if(flag == true)
        {
            UpdateDiamondText();
            flag = false;
        }
    }
    public void UpdateDiamondText()
    {
        diamondText.text = PlayerInventory.numberOfDiamonds.ToString();
    }
    public void UpdateDiamondText(PlayerInventory playerInventory)
    {
        diamondText.text = PlayerInventory.numberOfDiamonds.ToString();
    }
}

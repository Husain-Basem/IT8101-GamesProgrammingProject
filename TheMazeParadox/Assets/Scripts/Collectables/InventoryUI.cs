using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    // Static reference to the TextMeshProUGUI component for displaying the diamond count
    public static TextMeshProUGUI diamondText;

    // A flag to control whether to update the diamond count on start
    public bool flag = true;

    void Start()
    {
        // Get a reference to the TextMeshProUGUI component attached to this GameObject
        diamondText = GetComponent<TextMeshProUGUI>();

        // Check if the flag is true (for the first time)
        if (flag == true)
        {
            // Update the diamond count text
            UpdateDiamondText();

            // Set the flag to false to prevent further updates on start
            flag = false;
        }
    }

    // Static method to update the diamond count text from outside the class
    public static void UpdateDiamondText()
    {
        // Update the TextMeshProUGUI text with the current number of diamonds from PlayerInventory
        diamondText.text = PlayerInventory.numberOfDiamonds.ToString();
    }

    // Overloaded method to update the diamond count text with a PlayerInventory parameter
    public void UpdateDiamondText(PlayerInventory playerInventory)
    {
        // Update the TextMeshProUGUI text with the current number of diamonds from PlayerInventory
        diamondText.text = PlayerInventory.numberOfDiamonds.ToString();
    }
}

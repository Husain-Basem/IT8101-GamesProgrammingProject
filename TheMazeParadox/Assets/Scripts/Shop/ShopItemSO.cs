using System.Collections; // Import necessary namespace for collections
using System.Collections.Generic; // Import necessary namespace for generic collections
using UnityEngine; // Import the Unity Engine namespace

// Create a new scriptable object named ShopItemSO
// The CreateAssetMenu attribute allows you to create instances of this ScriptableObject from the Unity Editor
// It specifies the file name, menu name, and order in the "Assets/Create" menu
[CreateAssetMenu(fileName = "shopMenu", menuName = "scriptable objects/New shop Item", order = 1)]
public class ShopItemSO : ScriptableObject
{
    // Public fields to store information about a shop item
    public string title; // The title of the shop item
    public string description; // The description of the shop item
    public int baseCost; // The base cost or price of the shop item
}

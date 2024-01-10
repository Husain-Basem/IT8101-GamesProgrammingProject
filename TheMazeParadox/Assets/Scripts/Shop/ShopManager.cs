using System.Collections;
using System.Collections.Generic;
using TMPro; // Text Mesh Pro
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // UnityEvent that triggers when diamonds are collected
    public UnityEvent<PlayerInventory> OnDiamondCollected;

    // Public variables for managing coins and UI elements
    public int coins; // Current number of coins
    public TMP_Text coinUI; // Text Mesh Pro text to display the coin count
    public ShopItemSO[] shopItemsSO; // Array of ShopItemSO scriptable objects
    public GameObject[] shopItemsGO; // Array of GameObjects representing shop items
    public ShopTemplate[] shopPanels; // Array of ShopTemplate components for UI panels
    public Button[] myPurchaseBtns; // Array of purchase buttons

    private void Start()
    {
        // Initialize coins with the number of diamonds from PlayerInventory
        coins = PlayerInventory.numberOfDiamonds;

        // Set shop item GameObjects to active (visible) in the scene
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopItemsGO[i].SetActive(true);
        }

        // Update the coinUI text to display the initial coin count
        coinUI.text = "Diamonds: " + coins.ToString();

        // Load panel information for shop items
        LoadPanels();

        // Check and update the purchase button interactability
        CheckPurchaseable();
    }

    // Method to add coins
    public void AddCoins()
    {
        coins++;
        coinUI.text = "Diamonds: " + coins.ToString();
        CheckPurchaseable();
    }

    // Method to check and update purchase button interactability
    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (coins >= shopItemsSO[i].baseCost)
            {
                myPurchaseBtns[i].interactable = true;
            }
            else
            {
                myPurchaseBtns[i].interactable = false;
            }
        }
    }

    // Method to purchase a shop item
    public void PurchaseItem(int btnNo)
    {
        if (coins >= shopItemsSO[btnNo].baseCost)
        {
            // Deduct the cost from coins, update PlayerInventory, and UI
            coins = coins - shopItemsSO[btnNo].baseCost;
            PlayerInventory.numberOfDiamonds = coins;
            coinUI.text = "Diamonds: " + coins.ToString();
            InventoryUI.UpdateDiamondText();

            // Check and activate specific abilities if purchased
            if (shopItemsSO[btnNo].name == "Invisibility")
            {
                InvisibleAbility.bought = true;
            }
            if (shopItemsSO[btnNo].name == "Shoes")
            {
                SpeedAbility.bought = true;
            }

            // Check and update purchase button interactability
            CheckPurchaseable();
        }
    }

    // Method to load information into shop panels
    public void LoadPanels()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "Coins: " + shopItemsSO[i].baseCost.ToString();
        }
    }
}

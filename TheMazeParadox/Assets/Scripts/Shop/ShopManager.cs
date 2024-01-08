using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public UnityEvent<PlayerInventory> OnDiamondCollected;
    public int coins;
    public TMP_Text coinUI;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopItemsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;
    

    private void Start()
    {
        coins = PlayerInventory.numberOfDiamonds;
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopItemsGO[i].SetActive(true);
        }
        coinUI.text = "Diamonds: " + coins.ToString();
       LoadPanels();
       CheckPurchaseable();
    }


    public void AddCoins()
    {
        coins++;
        coinUI.text = "Diamonds: " + coins.ToString();
        CheckPurchaseable();
    }

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

    public void PurchaseItem(int btnNo)
    {
        if(coins >= shopItemsSO[btnNo].baseCost)
        {
            coins = coins - shopItemsSO[btnNo].baseCost;
            PlayerInventory.numberOfDiamonds = coins;
            coinUI.text = "Diamonds: " + coins.ToString();
            InventoryUI.UpdateDiamondText();
            CheckPurchaseable() ;

        }
    }

    public void LoadPanels()
    {
        for(int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "Coins: " + shopItemsSO[i].baseCost.ToString();
        }
    }
}

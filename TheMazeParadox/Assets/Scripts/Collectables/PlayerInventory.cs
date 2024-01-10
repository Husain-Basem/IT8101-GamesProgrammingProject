using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    // Static property to store the number of collected diamonds
    public static int numberOfDiamonds { get; set; }

    // UnityEvent that can be used to trigger events when diamonds are collected
    public UnityEvent<PlayerInventory> OnDiamondCollected;

    // Method called when a diamond is collected
    public void DiamondCollected()
    {
        // Increment the number of collected diamonds
        numberOfDiamonds++;

        // Invoke the OnDiamondCollected event, passing this PlayerInventory instance as a parameter
        OnDiamondCollected.Invoke(this);
    }
}

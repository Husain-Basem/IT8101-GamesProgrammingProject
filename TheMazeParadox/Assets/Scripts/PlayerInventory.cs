using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
   public int numberOfDiamonds { get; private set; }

    public UnityEvent<PlayerInventory> OnDiamondCollected;
    public void DiamondCollected()
    {
        numberOfDiamonds++;
        OnDiamondCollected.Invoke(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            FindObjectOfType<AudioManager>().Play("Pickup");
            playerInventory.DiamondCollected();
            gameObject.SetActive(false);
        }
    }
}

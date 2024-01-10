using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    // This method is called when the collider of another GameObject enters the trigger collider of this GameObject
    private void OnTriggerEnter(Collider other)
    {
        // Attempt to get a reference to the PlayerInventory component on the colliding GameObject
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        // Check if a PlayerInventory component is found on the colliding GameObject
        if (playerInventory != null)
        {
            // Find and play the "Pickup" sound using the AudioManager
            FindObjectOfType<AudioManager>().Play("Pickup");

            // Call the DiamondCollected method on the PlayerInventory component to update the count
            playerInventory.DiamondCollected();

            // Deactivate (hide) the Diamond GameObject, assuming it has a Collider and Renderer
            gameObject.SetActive(false);
        }
    }
}

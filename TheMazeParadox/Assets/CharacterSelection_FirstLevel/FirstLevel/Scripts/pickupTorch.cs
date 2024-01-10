using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pickupTorch : MonoBehaviour
{
    // References to UI element, torch objects, character models, and pickup sound
    public GameObject inttext, torch_table, torch_hand, character1, character2, character1R, character2R;

    // Audio source for the pickup sound
    public AudioSource pickup;

    // Flag to track interactability
    public bool interactable;

    // Called when another collider stays within the trigger collider
    void OnTriggerStay(Collider other)
    {
        // Check if the other collider has the "MainCamera" tag
        if (other.CompareTag("MainCamera"))
        {
            // Enable interaction text and set interactability to true
            inttext.SetActive(true);
            interactable = true;
        }
    }

    // Called when another collider exits the trigger collider
    void OnTriggerExit(Collider other)
    {
        // Check if the other collider has the "MainCamera" tag
        if (other.CompareTag("MainCamera"))
        {
            // Disable interaction text and set interactability to false
            inttext.SetActive(false);
            interactable = false;
        }
    }

    // Called every frame
    private void Update()
    {
        // Check if the pickup is interactable
        if (interactable)
        {
            // Check if the "E" key is pressed
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Disable interaction text and set interactability to false
                inttext.SetActive(false);
                interactable = false;

                // Play the pickup sound
                pickup.Play();

                // Disable the original character and enable the one holding the torch
                character1.SetActive(false);
                character2.SetActive(true);
                character1R.SetActive(false);
                character2R.SetActive(true);

                // Activate the torch in the hand and deactivate the one on the table
                torch_hand.SetActive(true);
                torch_table.SetActive(false);
            }
        }
    }
}

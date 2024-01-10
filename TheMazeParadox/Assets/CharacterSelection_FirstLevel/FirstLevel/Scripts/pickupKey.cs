using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pickupKey : MonoBehaviour
{
    // References to UI element, key GameObject, and blood event GameObject
    public GameObject inttext, key, bloodEvent;

    // Audio source for the pickup sound
    public AudioSource pickup;

    // Flags to track interactability and the occurrence of a scary event
    public bool interactable, scaryEvent;

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

                // Check if a scary event is set to occur
                if (scaryEvent)
                {
                    // Activate the blood event GameObject
                    bloodEvent.SetActive(true);
                }

                // Disable the key GameObject
                key.SetActive(false);
            }
        }
    }
}

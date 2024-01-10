using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour
{
    // References to UI element, light sources, and materials for light state
    public GameObject inttext, lightSource, lightSource1, lightSource2, lightSource3;

    // Variable to track the light switch state
    public bool toggle = true, interactable;

    // Materials for on and off light states
    public Material offlight, onlight;

    // Audio source for the light switch sound
    public AudioSource lightSwitchSound;

    // Animator component for controlling switch animations
    public Animator switchAnim;

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
        // Check if the switch is interactable
        if (interactable)
        {
            // Check if the "E" key is pressed
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Toggle the light switch state
                toggle = !toggle;

                // lightSwitchSound.Play(); // Animated Sound Trigger

                // Reset and set the "press" trigger for the switch animation
                switchAnim.ResetTrigger("press");
                switchAnim.SetTrigger("press");
            }
        }

        // Check the current state of the light switch
        if (toggle == false)
        {
            // Activate all light sources
            lightSource.SetActive(true);
            lightSource1.SetActive(true);
            lightSource2.SetActive(true);
            lightSource3.SetActive(true);
        }
        else
        {
            // Deactivate all light sources
            lightSource.SetActive(false);
            lightSource1.SetActive(false);
            lightSource2.SetActive(false);
            lightSource3.SetActive(false);
        }
    }
}

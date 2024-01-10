using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSounds : MonoBehaviour
{
    // References to audio sources for walking and sprinting sounds
    public AudioSource walkingSound, sprintingSound;

    // Flag to track whether the character is currently sprinting
    public bool isSprinting;

    void Update()
    {
        // Check if movement keys (W, A, S, D) are pressed
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            // Check if the sprint key (LeftShift) is pressed
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isSprinting = true;
            }

            // Check if the sprint key (LeftShift) is released
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isSprinting = false;
            }

            // Check if the character is sprinting
            if (isSprinting == true)
            {
                // Enable sprinting sound and disable walking sound
                sprintingSound.enabled = true;
                walkingSound.enabled = false;
            }
            else
            {
                // Disable sprinting sound and enable walking sound
                sprintingSound.enabled = false;
                walkingSound.enabled = true;
            }
        }
        else
        {
            // Disable both sprinting and walking sounds if no movement keys are pressed
            sprintingSound.enabled = false;
            walkingSound.enabled = false;
            isSprinting = false;
        }
    }
}

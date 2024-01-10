using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscareEvent : MonoBehaviour
{
    // Reference to the GameObject representing the jumpscare
    public GameObject scare;

    // Reference to the AudioSource for the jumpscare sound
    public AudioSource scareSound;

    // Reference to the Collider component for collision handling
    public Collider collision;

    // Called when another collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Activate the jumpscare GameObject
            scare.SetActive(true);

            // scareSound.Play();

            // Disable the Collider component to prevent repeated triggers
            collision.enabled = false;
        }
    }
}

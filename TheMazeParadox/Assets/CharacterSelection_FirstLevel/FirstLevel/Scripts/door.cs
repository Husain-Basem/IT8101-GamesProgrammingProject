using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class door : MonoBehaviour
{
    // References to UI elements, key object, and text for locked state
    public GameObject inttext, key, lockedText;

    // Flags to track interactability and door state toggling
    public bool interactable, toggle;

    // Audio sources for door opening and locked sound effects
    public AudioSource doorSoundOpen, doorSoundLocked;

    // Animator component for controlling door animations
    public Animator doorAnim;

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
        // Check if the object is interactable
        if (interactable)
        {
            // Check if the "E" key is pressed
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Toggle the door state
                toggle = !toggle;

                // Check if the key is not active (door is not locked)
                if (!key.activeSelf)
                {
                    // Perform door animations based on the toggle state
                    if (toggle)
                    {
                        // Play the "open" animation
                        doorAnim.ResetTrigger("close");
                        doorAnim.SetTrigger("open");
                    }
                    else
                    {
                        // Play the "close" animation
                        doorAnim.ResetTrigger("open");
                        doorAnim.SetTrigger("close");
                    }

                    // Disable interaction text and set interactability to false
                    inttext.SetActive(false);
                    interactable = false;
                }
                else // The door is locked
                {
                    // Display locked text, play locked sound effect, and start coroutine to disable the text after 2 seconds
                    lockedText.SetActive(true);
                    doorSoundLocked.Play();
                    StopCoroutine("disableText");
                    StartCoroutine("disableText");
                }
            }
        }
    }

    // Coroutine to disable the locked text after a specified wait time
    IEnumerator disableText()
    {
        yield return new WaitForSeconds(2.0f);
        lockedText.SetActive(false);
    }
}

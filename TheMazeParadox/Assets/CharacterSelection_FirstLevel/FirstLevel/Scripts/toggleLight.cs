using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleLight : MonoBehaviour
{
    // References to spotlight, flame, and toggle sound
    public GameObject Spotlight, Flame;
    public AudioSource toggleSound;

    // Flag to track the state of the lights
    public bool onOff;

    // Update is called once per frame
    void Update()
    {
        // Check the state of onOff and activate/deactivate lights accordingly
        if (onOff)
        {
            Spotlight.SetActive(true);
            Flame.SetActive(true);
        }
        else
        {
            Spotlight.SetActive(false);
            Flame.SetActive(false);
        }

        // Check for input to toggle the lights
        ToggleLights();
    }

    // Method to toggle the lights on key press
    public void ToggleLights()
    {
        // Check if the "L" key is pressed
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Toggle the onOff flag
            onOff = !onOff;
        }
    }
}

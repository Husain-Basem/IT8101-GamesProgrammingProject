using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraChange : MonoBehaviour
{
    // Reference to the first-person and third-person cameras
    public GameObject FirstCamera, ThirdCamera;

    // Variable to track the current camera mode (0 for third-person, 1 for first-person)
    public int CameraMode;

    // Update is called once per frame
    void Update()
    {
        // Check if the "Camera" button is pressed
        if (Input.GetButtonDown("Camera"))
        {
            // Toggle between camera modes (0 for third-person, 1 for first-person)
            if (CameraMode == 1)
            {
                CameraMode = 0;
            }
            else
            {
                CameraMode += 1;
            }

            // Start a coroutine to handle camera mode change with a slight delay
            StartCoroutine(CamChange());
        }
    }

    // Coroutine to handle camera mode change with a slight delay
    IEnumerator CamChange()
    {
        // Wait for a short duration (0.01 seconds) to ensure smooth camera mode transition
        yield return new WaitForSeconds(0.01f);

        // Check the current camera mode and activate/deactivate cameras accordingly
        if (CameraMode == 0)
        {
            // Activate third-person camera and deactivate first-person camera
            ThirdCamera.SetActive(true);
            FirstCamera.SetActive(false);
        }
        else if (CameraMode == 1)
        {
            // Activate first-person camera and deactivate third-person camera
            FirstCamera.SetActive(true);
            ThirdCamera.SetActive(false);
        }
    }
}
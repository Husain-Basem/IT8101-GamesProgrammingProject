using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour
{
    // Sensitivity factor for rotation
    [SerializeField] private float Sensitivity;

    // Flag to track if the object is currently being rotated
    public bool isRotating;

    // Update is called once per frame
    void Update()
    {
        // Check if the Fire1 button (usually left mouse button) is held down
        if (Input.GetButton("Fire1"))
        {
            // Set isRotating to true and initiate object rotation
            isRotating = true;
            RotateObject();
        }
        else
        {
            // Set isRotating to false when Fire1 button is released
            isRotating = false;
        }

        // Return the object to its original rotation if not currently rotating
        ReturnRotateObject();

        // Hide or show the mouse cursor based on rotation status
        HideMouse();
    }

    // Method to rotate the object based on mouse input
    public void RotateObject()
    {
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;

        // Apply rotation based on mouse input
        transform.rotation = new Quaternion(mouseY, mouseX, 0, 1) * transform.rotation;
    }

    // Method to return the object to its original rotation when not rotating
    public void ReturnRotateObject()
    {
        if (!isRotating)
        {
            // Gradually return the object to its original rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * 10);
        }
    }

    // Method to hide or show the mouse cursor based on rotation status
    public void HideMouse()
    {
        if (!isRotating)
        {
            // Show the mouse cursor when not rotating
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // Hide the mouse cursor when rotating
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}

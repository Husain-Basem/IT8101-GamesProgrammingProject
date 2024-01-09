using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSounds : MonoBehaviour
{

    public AudioSource walkingSound, sprintingSound;
    public bool isSprinting;
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){

            if (Input.GetKey(KeyCode.LeftShift))
            {
                isSprinting = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift)) 
            {
                isSprinting = false;
            }
            if(isSprinting == true)
            {
                sprintingSound.enabled = true;
                walkingSound.enabled = false;
            }
            if (isSprinting == false)
            {
                sprintingSound.enabled = false;
                walkingSound.enabled = true;
            }
        }
        else
        {
            sprintingSound.enabled = false;
            walkingSound.enabled = false;
            isSprinting = false;
        }
    }
}

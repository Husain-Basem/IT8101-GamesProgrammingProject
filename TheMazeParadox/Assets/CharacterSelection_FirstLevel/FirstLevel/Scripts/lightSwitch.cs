using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour
{
    public GameObject inttext, lightSource, lightSource1, lightSource2, lightSource3;
    public bool toggle = true, interactable;
    public Material offlight, onlight;
    public AudioSource lightSwitchSound;
    public Animator switchAnim;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
        }
    }

    private void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E)) {
                toggle = !toggle;
                //lightSwitchSound.Play();
                switchAnim.ResetTrigger("press");
                switchAnim.SetTrigger("press");
            }
        }
        if (toggle == false)
        {
            lightSource.SetActive(true);
            lightSource1.SetActive(true);
            lightSource2.SetActive(true);
            lightSource3.SetActive(true);
        }
        if (toggle == true)
        {
            lightSource.SetActive(false);
            lightSource1.SetActive(false);
            lightSource2.SetActive(false);
            lightSource3.SetActive(false);
        }
    }
}


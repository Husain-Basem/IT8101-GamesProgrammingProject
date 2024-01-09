using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pickupTorch : MonoBehaviour
{
    public GameObject inttext, torch_table, torch_hand, character1, character2, character1R, character2R;
    public AudioSource pickup;
    public bool interactable;

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
            if (Input.GetKeyDown(KeyCode.E))
            {
                inttext.SetActive(false);
                interactable = false;
                pickup.Play();
                character1.SetActive(false);
                character2.SetActive(true);
                character1R.SetActive(false);
                character2R.SetActive(true);
                torch_hand.SetActive(true);
                torch_table.SetActive(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject inttext, key, lockedText;
    public bool interactable, toggle;
    public AudioSource doorSoundOpen;
    public AudioSource doorSoundLocked;
    public Animator doorAnim;

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
                toggle = !toggle;

                if (key.activeSelf == false)
                {
                    if (toggle == true)
                    {
                        //doorSoundOpen.Play();
                        doorAnim.ResetTrigger("close");
                        doorAnim.SetTrigger("open");
                    }
                    if (toggle == false)
                    {
                        //doorSoundOpen.Play();
                        doorAnim.ResetTrigger("open");
                        doorAnim.SetTrigger("close");
                    }
                    inttext.SetActive(false);
                    interactable = false;
                }
                if (key.activeSelf == true)
                {
                    lockedText.SetActive(true);
                    doorSoundLocked.Play();
                    StopCoroutine("disableText");
                    StartCoroutine("disableText");
                }
            }
        }
    }
    IEnumerator disableText()
    {
        yield return new WaitForSeconds(2.0f);
        lockedText.SetActive(false);
    }
}


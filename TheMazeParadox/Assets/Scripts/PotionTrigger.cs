using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionTrigger : MonoBehaviour
{
    // variables
    [SerializeField]
    DialogueManager dialogueManager;
    [SerializeField]
    DialogueTrigger dialogueTrigger;
    [SerializeField]
    GameObject dialogueBox;
    // following variables are used to prevent skipping lines
    float cooldown = 10f;
    float lastClickTime = 0f;

    private void Update()
    {
        // get current time
        float currentTime = Time.time;
        // get the time between current click and last click
        float diffSecs = currentTime - lastClickTime;
        // if player clicks after the cooldown, proceeed
        if (diffSecs >= cooldown)
        {
            // check if player clicks on mouse to continue dialogue message 
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
            {
                // set last click time to current time
                lastClickTime = currentTime;
                // play dialogue
                if (dialogueManager.DisplayNextSentence() == false)
                {
                    // if no more sentences are available, close the dialogue canvas
                    dialogueBox.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        dialogueBox.SetActive(true);
        dialogueTrigger.TriggerDialogue();
    }

    private void OnTriggerExit(Collider other)
    {
        dialogueBox.SetActive(false);
    }
}


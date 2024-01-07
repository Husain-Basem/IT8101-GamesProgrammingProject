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

    private void Update()
    {

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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class box : MonoBehaviour
{
    // timeline variable
    [SerializeField]
    private PlayableDirector timelineCinematic;
    [SerializeField]
    private GameObject keyItem;
    [SerializeField]
    private GameObject lanternTrigger;
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
        // if player has collected the key item, play cutscene and disable trigger
        if (keyItem.activeSelf == false)
        {
            timelineCinematic.Play();
            Debug.Log("Player can pass the tree");
            lanternTrigger.SetActive(false);
        } else
        {
            dialogueBox.SetActive(true);
            dialogueTrigger.TriggerDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        dialogueBox.SetActive(false);
    }
}

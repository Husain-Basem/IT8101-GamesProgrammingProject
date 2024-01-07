using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class MoveLog : MonoBehaviour
{

    //variables
    public GameObject Log;
    public GameObject LogDestination;
    public float speed; // set speed of moving log
    [SerializeField]
    GameObject keyItem;
    [SerializeField]
    float rotateSpeed; // used to set the rotation speed of the log
    [SerializeField]
    Vector3 rotationDirection = new Vector3();
    private bool moveLog = false;
    [SerializeField]
    DialogueManager dialogueManager;
    [SerializeField]
    DialogueTrigger dialogueIntro;
    [SerializeField]
    DialogueTrigger dialogueFinished;
    [SerializeField]
    GameObject dialogueBox;
    bool levelFinished = false;
    // following variables are used to prevent skipping lines
    float cooldown = 0.2f;
    float lastClickTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (moveLog == true)
        {
            // move the log to the position of the empty object
            Log.transform.position = Vector3.MoveTowards(Log.transform.position, LogDestination.transform.position, speed);
            Log.transform.Rotate(rotateSpeed * rotationDirection * Time.deltaTime);

            // if the log as reached the destitation, set moveLog to false to stop rotating the log.
            if (Log.transform.position.x == LogDestination.transform.position.x)
            {
                moveLog = false;
            }
        }
        // check if player clicks on mouse to continue dialogue message 
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            Debug.Log("Key pressed");
            // get current time
            float currentTime = Time.time;
            // get the time between current click and last click
            float diffSecs = currentTime - lastClickTime;
            // if player clicks after the cooldown, proceeed
            if (diffSecs >= cooldown)
            {

                Debug.Log("Cooldown");
                // set last click time to current time
                lastClickTime = currentTime;

                bool next = dialogueManager.DisplayNextSentence();
                // play dialogue
                if (next == false)
                {
                    // if no more sentences are available, close the dialogue canvas
                    dialogueBox.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // open dialogue canvas
        dialogueBox.SetActive(true);
        // if player has collected the key item to move the log, open path to next level
        if (keyItem.activeSelf == false)
        {
            moveLog = true;
            levelFinished = true;
            dialogueFinished.TriggerDialogue();
        }
        // if key item has not yet been selected, start intro dialogue
        else if (!levelFinished)
        {
            dialogueIntro.TriggerDialogue();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        // close dialogue canvas
        dialogueBox.SetActive(false);
    }
}

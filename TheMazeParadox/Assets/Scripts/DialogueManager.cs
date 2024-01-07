using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // variables
    private Queue<string> sentences;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // method to start dialogue
    public void StartDialogue (Dialogue dialogue)
    {
        // set name
        nameText.text = dialogue.name;

        // clear previous sentences
        sentences.Clear();

        // go through all strings in dialogue and add it tot the queue
        foreach (string sentence in dialogue.sentences)
        { 
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public bool DisplayNextSentence ()
    {

        if (sentences.Count == 0)
        {
            return false;
        }

        Debug.Log("DisplayedNextDialogue was called!");

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

        return true;
    }

}

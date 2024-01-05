using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
   public PlayableDirector playableDirector;
    private bool cutscenePlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player") && !cutscenePlayed)
        {
            // Play the cutscene
            playableDirector.Play();
            cutscenePlayed = true;

            // Optionally, disable player control here
        }
    }
}

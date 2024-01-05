using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class CutsceneTrigger : MonoBehaviour
{
public PlayableDirector playableDirector;
    public Camera mainCamera; // Assign your main camera in the inspector
    public Camera cutsceneCamera; // Assign your cutscene camera in the inspector
    private bool cutscenePlayed = false;
    public NPCFollow npcFollowScript;
    public GameObject player;
    public TextMeshProUGUI textMeshPro;


    private void Awake()
    {
        // Subscribe to the stopped event to handle when the cutscene ends
        playableDirector.stopped += OnCutsceneStopped;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player") && !cutscenePlayed)
        {
            // Optionally, disable player control here

            // Play the cutscene
            playableDirector.Play();
            cutscenePlayed = true;

            // Switch to cutscene camera
            if (cutsceneCamera)
            {
                cutsceneCamera.gameObject.SetActive(true);
                player.SetActive(false);
                if (mainCamera) mainCamera.gameObject.SetActive(false);
            }
        }
    }

    private void OnCutsceneStopped(PlayableDirector aDirector)
    {
        if (playableDirector == aDirector)
        {
            // Switch back to the main camera
            player.SetActive(true);
            if (mainCamera) mainCamera.gameObject.SetActive(true);
            if (cutsceneCamera) cutsceneCamera.gameObject.SetActive(false);

            // Start following the main character
            npcFollowScript.StartFollowing();

            // Deactivate the TextMeshPro object
            textMeshPro.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        playableDirector.stopped -= OnCutsceneStopped;
    }

}

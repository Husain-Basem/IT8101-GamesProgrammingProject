using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class CutsceneTrigger : MonoBehaviour
{
public PlayableDirector playableDirector;
    private Camera mainCamera; 
    public Camera cutsceneCamera; 
    private bool cutscenePlayed = false;
    public NPCFollow npcFollowScript;
    private GameObject player; 
    public TextMeshProUGUI textMeshPro;
    public NPCPatrol npcPatrolScript;

    private void Awake()
    {
        // Find all cameras and set the first active one as the mainCamera
        Camera[] allCameras = Camera.allCameras;
        foreach (Camera cam in allCameras)
        {
            if (cam.gameObject.activeSelf)
            {
                mainCamera = cam;
                break;
            }
        }

        if (mainCamera == null)
        {
            Debug.LogWarning("CutsceneTrigger: No active main camera found.");
        }

        // Find the active player in the scene and set it as the player GameObject
        GameObject[] potentialPlayers = GameObject.FindGameObjectsWithTag("Player");
        foreach (var potentialPlayer in potentialPlayers)
        {
            if (potentialPlayer.activeInHierarchy)
            {
                player = potentialPlayer;
                break;
            }
        }

        // If no active player was found, log a warning
        if (player == null)
        {
            Debug.LogWarning("CutsceneTrigger: No active player found.");
        }

        // Subscribe to the stopped event to handle when the cutscene ends
        playableDirector.stopped += OnCutsceneStopped;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player") && !cutscenePlayed)
        {
            //stop patrolling
            npcPatrolScript.StopPatrol();

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

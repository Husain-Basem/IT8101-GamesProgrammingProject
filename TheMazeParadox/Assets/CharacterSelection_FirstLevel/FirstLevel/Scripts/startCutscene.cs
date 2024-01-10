using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCutscene : MonoBehaviour
{
    // References to cutscene camera, player GameObject, and cutscene duration
    public GameObject cutsceneCamera, player;
    public float cutsceneTime;

    // Called when the script is first loaded
    private void Start()
    {
        // Start the cutscene coroutine
        StartCoroutine(cutscene());
    }

    // Coroutine to handle the cutscene
    IEnumerator cutscene()
    {
        // Wait for the specified cutscene duration
        yield return new WaitForSeconds(cutsceneTime);

        // Activate the player GameObject and deactivate the cutscene camera
        player.SetActive(true);
        cutsceneCamera.SetActive(false);
    }
}

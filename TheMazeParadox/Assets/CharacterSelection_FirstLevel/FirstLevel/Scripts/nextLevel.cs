using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    // Name of the scene to load when the player enters the trigger zone
    public string sceneName;

    // Level number to save using PlayerPrefs
    public int levelNumber;

    // Called when another collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has the "Player" tag
        if (other.gameObject.CompareTag("Player"))
        {
            // Save the current level number using PlayerPrefs
            PlayerPrefs.SetInt("level", levelNumber);
            PlayerPrefs.Save();

            // Load the specified scene
            SceneManager.LoadScene(sceneName);
        }
    }
}

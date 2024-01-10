using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Public variable to store the name of the scene to be loaded
    public string sceneName;

    // Method to change the scene and add it to the current scene
    public void changeScene()
    {
        // Load the specified scene additively (alongside the current scene)
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    // Method to unload the specified scene
    public void UnloadScene()
    {
        // Unload the scene with the specified name
        SceneManager.UnloadScene(sceneName);
    }
}

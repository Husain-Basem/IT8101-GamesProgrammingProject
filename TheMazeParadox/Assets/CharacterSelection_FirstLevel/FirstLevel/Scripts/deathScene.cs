using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScene : MonoBehaviour
{
    // Name of the scene to load after a specified wait time
    public string SceneName;

    // Time to wait before loading the specified scene
    public float waitTime;

    // Start is called before the first frame update
    private void Start()
    {
        // Start the coroutine to load the scene after the specified wait time
        StartCoroutine(loadToStart());
    }

    // Coroutine to load the specified scene after a wait time
    IEnumerator loadToStart()
    {
        // Wait for the specified time before proceeding
        yield return new WaitForSeconds(waitTime);

        // Load the specified scene
        SceneManager.LoadScene(SceneName);
    }
}

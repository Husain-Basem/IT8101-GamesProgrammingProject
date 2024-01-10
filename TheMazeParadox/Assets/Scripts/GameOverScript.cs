using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void Start()
    {

    }

    public void Update()
    {
        
    }

    public void ReloadLevel()
    {
        // reload current scene
        string currentSceneName = SceneManager.GetActiveScene().name;
        ThirdPersonMovement.isGameOver = false;
        animationStateController.isGameOver = false;
        SceneManager.LoadScene(currentSceneName);
    }
}

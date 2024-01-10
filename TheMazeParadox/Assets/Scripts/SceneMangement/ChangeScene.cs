using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
 
    public void changeScene()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        Time.timeScale = 0f;
    }
    public void UnloadScene()
    {
        SceneManager.UnloadScene(sceneName);
        Time.timeScale = 1f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScene : MonoBehaviour
{
    public string SceneName;
    public float waitTime;

    private void Start()
    {
        StartCoroutine(loadToStart());
    }
    IEnumerator loadToStart()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneName);
    }
}

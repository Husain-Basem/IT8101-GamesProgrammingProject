using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadToStart : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(loadToMenu());
    }
    IEnumerator loadToMenu()
    {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene("MainMenu");
    }
}

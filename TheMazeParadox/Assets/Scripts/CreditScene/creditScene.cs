using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditScene : MonoBehaviour
{
    public GameObject portal;
    public string scene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Colide");
            SceneManager.LoadScene(scene);
        }
    }
}

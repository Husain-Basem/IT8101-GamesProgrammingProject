using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadLevelThree : MonoBehaviour
{
      private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("level-3"); // load level 3
    }

}

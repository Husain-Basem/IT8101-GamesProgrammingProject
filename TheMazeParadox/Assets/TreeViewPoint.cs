using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TreeViewPoint : MonoBehaviour
{
    [SerializeField]
    GameObject lanternLightTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (lanternLightTrigger.activeSelf != false)
        {
            SceneManager.LoadScene("level-3");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TreeViewPoint : MonoBehaviour
{
    [SerializeField]
    GameObject lanternLightTrigger;
    [SerializeField]
    GameObject gameOverUI;

    private void OnTriggerEnter(Collider other)
    {
        if (lanternLightTrigger.activeSelf != false)
        {
            // show gameover and stop player movement
            gameOverUI.SetActive(true);
            ThirdPersonMovement.isGameOver = true;
            animationStateController.isGameOver = true;
        }
    }
}

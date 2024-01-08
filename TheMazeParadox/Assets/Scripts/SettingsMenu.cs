using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{

    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerInventory.numberOfDiamonds = 0;
    }

    public void SaveGame()
    {
        SaveGameManager.SaveGame();
    }

    public void LoadGame()
    {
        SaveGameManager.LoadGame();
    }

    public void Quit()
    {
        
        SceneManager.LoadScene("MainMenu");
    }
}

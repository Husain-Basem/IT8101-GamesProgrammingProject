using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    // Restart the current scene
    public void restartScene()
    {
        // Load the current active scene, effectively restarting it
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Reset the number of diamonds in the PlayerInventory to 0
        PlayerInventory.numberOfDiamonds = 0;
    }

    // Save the game state
    public void SaveGame()
    {
        // Call the SaveGame method from the SaveGameManager class to save the game state
        SaveGameManager.SaveGame();
    }

    // Load the saved game state
    public void LoadGame()
    {
        // Call the LoadGame method from the SaveGameManager class to load the game state
        SaveGameManager.LoadGame();
    }

    // Quit the game and return to the main menu scene
    public void Quit()
    {
        // Load the "MainMenu" scene to return to the main menu
        SceneManager.LoadScene("MainMenu");
    }
}

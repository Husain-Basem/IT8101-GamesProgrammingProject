using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

// Static class to manage saving and loading game data
public static class SaveGameManager
{
    // Static variable to hold the current game's save data
    public static SaveData CurrentSaveData = new SaveData();

    // Flag to indicate whether a save was loaded
    public static bool loaded = false;

    // Directory path where save data will be stored
    public const string directory = "/SaveData/";

    // Name of the save file
    public const string FileName = "SaveGame.sav";

    // Static variables to store player position and rotation
    public static Vector3 p;
    public static Quaternion q;

    // Method to save the game data
    public static bool SaveGame()
    {
        // Construct the full directory path
        var dir = Application.persistentDataPath + directory;

        // Store the player's data in the CurrentSaveData instance
        CurrentSaveData.playerData = PlayerSaveData.MyData;

        // If the directory doesn't exist, create it
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        // Serialize the save data to JSON format
        string json = JsonUtility.ToJson(CurrentSaveData, true);

        // Write the JSON data to the save file
        File.WriteAllText(dir + FileName, json);

        // Copy the directory path to the system clipboard (useful for debugging)
        GUIUtility.systemCopyBuffer = dir;

        // Return a success flag
        return true;
    }

    // Method to load the game data
    public static void LoadGame()
    {
        // Construct the full file path for the save data
        string fullPath = Application.persistentDataPath + directory + FileName;

        // Create a temporary SaveData instance
        SaveData tempData = new SaveData();

        // Check if the save file exists
        if (File.Exists(fullPath))
        {
            // Read the JSON data from the save file and deserialize it into tempData
            string json = File.ReadAllText(fullPath);
            tempData = JsonUtility.FromJson<SaveData>(json);

            // Update the number of diamonds in the player's inventory
            PlayerInventory.numberOfDiamonds = tempData.playerData.daimonds;

            // Load the scene saved in the player's data
            SceneManager.LoadScene(tempData.playerData.playerScene);

            // Set the player's position and rotation from the saved data
            p = tempData.playerData.PlayerPosition;
            q = tempData.playerData.PlayerRotation;

            // Set the loaded flag to true
            loaded = true;
        }
        else
        {
            Debug.LogError("Save file does not exist!");
        }

        // Update the CurrentSaveData with the loaded data
        CurrentSaveData = tempData;
    }
}

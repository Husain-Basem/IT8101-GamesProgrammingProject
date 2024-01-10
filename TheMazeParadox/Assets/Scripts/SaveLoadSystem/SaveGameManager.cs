using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public static class SaveGameManager
{
    public static SaveData CurrentSaveData = new SaveData();
    public static bool loaded = false;
    public const string directory = "/SaveData/";
    public const string FileName = "SaveGame.sav";
    public static Vector3 p;
    public static Quaternion q;


    public static bool SaveGame()
    {
        var dir = Application.persistentDataPath + directory;

        CurrentSaveData.playerData = PlayerSaveData.MyData;

        if(!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(CurrentSaveData, true);
        File.WriteAllText(dir + FileName, json);

        GUIUtility.systemCopyBuffer = dir;

        return true;
    }
    
    public static void LoadGame()
    {
        string fullPath = Application.persistentDataPath + directory + FileName;
        SaveData tempData = new SaveData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            tempData = JsonUtility.FromJson<SaveData>(json);
            PlayerInventory.numberOfDiamonds = tempData.playerData.daimonds;
            SceneManager.LoadScene(tempData.playerData.playerScene);
            p = tempData.playerData.PlayerPosition;
            q = tempData.playerData.PlayerRotation;
            loaded = true;
            Time.timeScale = 1f;
        }
        else
        {
            Debug.LogError("Save file does not exist!");
        }
        CurrentSaveData = tempData;
    }
}

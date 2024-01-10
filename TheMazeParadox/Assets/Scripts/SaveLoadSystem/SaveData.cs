using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mark the class as Serializable, allowing it to be serialized and displayed in the Unity Inspector
[System.Serializable]
public class SaveData
{
    // Public variable to store player data (an instance of PlayerData)
    public PlayerData playerData = new PlayerData();
}

using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSaveData : MonoBehaviour
{
    public static PlayerData MyData = new PlayerData();

    void Start()
    {
        if(SaveGameManager.loaded == true)
        {
            transform.position = SaveGameManager.p;
            transform.rotation = SaveGameManager.q;
            SaveGameManager.loaded = false;
        }
        
    }

    void Update()
    {
        MyData.PlayerPosition = transform.position;
        MyData.PlayerRotation = transform.rotation;
        MyData.daimonds = PlayerInventory.numberOfDiamonds;
        MyData.playerScene = SceneManager.GetActiveScene().name;
        
        
    }
}

[System.Serializable]
public struct PlayerData
{
    public Vector3 PlayerPosition;
    public Quaternion PlayerRotation;
    public int daimonds;
    public string playerScene;
}
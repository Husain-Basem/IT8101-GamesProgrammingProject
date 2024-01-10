using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSaveData : MonoBehaviour
{
    // Static variable to store player data (a structure)
    public static PlayerData MyData = new PlayerData();

    // Start is called before the first frame update
    void Start()
    {
        // Check if the game was loaded from a saved state
        if (SaveGameManager.loaded == true)
        {
            // If loaded, set the player's position and rotation from saved data
            transform.position = SaveGameManager.p;
            transform.rotation = SaveGameManager.q;

            // Reset the 'loaded' flag to false to prevent reloading on future starts
            SaveGameManager.loaded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update the player's data structure with current position, rotation, diamonds, and scene
        MyData.PlayerPosition = transform.position;
        MyData.PlayerRotation = transform.rotation;
        MyData.daimonds = PlayerInventory.numberOfDiamonds; // Typo? Should it be 'diamonds'?
        MyData.playerScene = SceneManager.GetActiveScene().name;
    }
}

// A structure (struct) to store player data
[System.Serializable]
public struct PlayerData
{
    public Vector3 PlayerPosition; // Player's position in the scene
    public Quaternion PlayerRotation; // Player's rotation in the scene
    public int daimonds; // Number of diamonds (possible typo, should it be 'diamonds'?)
    public string playerScene; // Name of the current scene
}

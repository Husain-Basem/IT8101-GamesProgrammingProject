using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To Switch Scenes after Character Confirmation/Selection
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    // Reference to Objects
    private GameObject[] characterList;
    private int index;
    public string sceneName;

    // Initializes Once Game Starts
    private void Start()
    {
        //also retains the character after reloading the game
        index = PlayerPrefs.GetInt("SelectedCharacter");

        // childCount returns the number of characters in the object
        characterList = new GameObject[transform.childCount];

        // for every children object in the parent object
        // fills array with models
        for (int i = 0; i < transform.childCount; i++)
        {
            // returns the child at the index
            characterList[i] = transform.GetChild(i).gameObject;
        }


        // toggles off / hides the models renderer
        foreach(GameObject go in characterList) 
        {
            go.SetActive(false);
        }

        // toggle the selected character
        if (characterList[index])
        {
            characterList[index].SetActive(true);
        }
    }

    public void TogglePrevious() 
    {
        // toggle off current model
        characterList[index].SetActive(false);

        index--; // or index -=1; or index = index - 1
        // safety check for array range 
        if(index < 0)
        {
            index = characterList.Length - 1;
        }

        // toggle in the new model
        characterList[index].SetActive(true);
    }

    public void ToggleNext()
    {
        // toggle off current model
        characterList[index].SetActive(false);

        index++; // or index +=1; or index = index + 1
        // safety check for array range 
        if (index == characterList.Length)
        {
            index = 0;
        }

        // toggle in the new model
        characterList[index].SetActive(true);
    }

    public void ConfirmCharacter()
    {
        //saving the selected character
        PlayerPrefs.SetInt("SelectedCharacter", index);
        //loading the scene name
        SceneManager.LoadScene(sceneName);
    }
}

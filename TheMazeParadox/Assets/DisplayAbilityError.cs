using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DisplayAbilityError : MonoBehaviour
{
    // varaible 
    [SerializeField]
    public GameObject fieldText;
    float hideTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!InvisibleAbility.bought)
            {
                Display();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!SpeedAbility.bought)
            {
                Display();
            }
        }

        if (fieldText.activeSelf && Time.time >= hideTime)
        {
            fieldText.SetActive(false);
        }
    }

    public void Display()
    {
        Debug.Log("Displayed!");
        fieldText.SetActive(true);
        hideTime = Time.time + 2f;
    }
}

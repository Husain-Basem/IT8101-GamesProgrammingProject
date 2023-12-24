using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
public class pressurePlate : MonoBehaviour
{
    // variables
    [SerializeField]
    GameObject plate;
    [SerializeField]
    GameObject wall;
    [SerializeField]
    GameObject debris;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // destory the wall
        Destroy(wall);
        // display the debris
        debris.SetActive(true);
        // destory the plate object
        Destroy(plate);
        Debug.Log("Pressed on Pressure Plate!");
    }
}

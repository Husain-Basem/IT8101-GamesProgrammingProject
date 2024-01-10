using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.SceneManagement;

public class LichRaycast : MonoBehaviour
{
    // variables
    bool hit;

    // Start function
    void Start()
    {
        hit = false;
    }
    // Update is called once per frame
    void Update()
    {
        // check if raycast hit an object
        hit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 200f);
        // show raycast in scene view
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
        // if raycasts detects any object
        if (hit)
        {
            // check if the raycast detected a player
            if (hitinfo.collider.gameObject.CompareTag("Player"))
            {
                // fail the level
                Debug.Log("Player Found! Game Over.");
                SceneManager.LoadScene("DeathScene-Level-3");
                // SceneManager.LoadScene("level-3");
            }

        }
    }
}

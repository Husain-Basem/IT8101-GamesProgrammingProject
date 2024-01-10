using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class spawnEnemy : MonoBehaviour
{
    // References to enemy GameObject, walls, and collision Collider
    public GameObject enemy, wall1, wall2, wall3;
    public Collider collision;

    // Flag to control the activation of walls
    public bool walls;

    // Called when another collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Activate the enemy GameObject
            enemy.SetActive(true);

            // Check if the walls flag is set to true
            if (walls)
            {
                // Activate specific walls based on the walls flag
                wall1.SetActive(true);
                wall2.SetActive(true);
                wall3.SetActive(false);
            }

            // Disable the collision to prevent repeated triggers
            collision.enabled = false;
        }
    }
}

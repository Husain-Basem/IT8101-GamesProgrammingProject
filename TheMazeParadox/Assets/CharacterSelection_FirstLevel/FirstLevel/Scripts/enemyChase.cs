using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyChase : MonoBehaviour
{
    // Reference to the NavMeshAgent component for enemy navigation
    public NavMeshAgent ai;

    // Reference to the player's transform for tracking
    public Transform player;

    // Variable to store the destination vector for the enemy
    Vector3 dest;

    // Called every frame
    private void Update()
    {
        // Set the destination for the enemy to the player's current position
        dest = player.position;
        ai.destination = dest;
    }
}

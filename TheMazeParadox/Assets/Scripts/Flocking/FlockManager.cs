using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{

    [Header("Wall Avoidance Settings")]
    [Range(1.0f, 10.0f)]
    public float wallDetectionDistance; // Distance at which NPCs detect walls
    [Range(1.0f, 10.0f)]
    public float maxWallDistance; // Maximum distance to a wall before making a turn
    // Static reference to the FlockManager instance (singleton)
    public static FlockManager FM;

    // Prefab for the NPC (Non-Player Character)
    public GameObject Npc;

    // Number of NPCs in the flock
    public int numNpc = 20;

    // Array to store all spawned NPCs
    public GameObject[] allNpc;

    // Define limits for the flock's movement in the X and Z axes
    public Vector3 limits = new Vector3(5, 0, 5);

    // Reference to the player GameObject
    public GameObject player;

    // Target position for the flock to move towards
    public Vector3 goalPos = Vector3.zero;

    [Header("NPC Settings")]
    [Range(0.0f, 5.0f)]
    public float minSpeed; // Minimum speed of NPCs
    [Range(0.0f, 5.0f)]
    public float maxSpeed; // Maximum speed of NPCs
    [Range(1.0f, 10.0f)]
    public float neighbourDistance; // Distance at which NPCs consider each other neighbors
    [Range(1.0f, 5.0f)]
    public float rotationSpeed; // Speed at which NPCs rotate to align with the group

    void Start()
    {
        // Create an array to hold all the NPCs
        allNpc = new GameObject[numNpc];

        // Instantiate NPCs at random positions within the specified limits
        for (int i = 0; i < numNpc; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-limits.x, limits.x), 0, Random.Range(-limits.z, limits.z));
            allNpc[i] = Instantiate(Npc, pos, Quaternion.identity);
        }

        // Set the FlockManager as a singleton
        FM = this;

        // Find and store a reference to the player GameObject with the "Player" tag
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Ensure player GameObject is found before updating goalPos
        if (player != null && !player.CompareTag("Invisible"))
        {
            goalPos = player.transform.position;
        }
    }
}
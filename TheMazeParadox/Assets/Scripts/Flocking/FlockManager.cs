using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public static FlockManager FM;
    public GameObject Npc;
    public int numNpc = 20;
    public GameObject[] allNpc;
    public Vector3 limits = new Vector3(5, 0, 5);
    public GameObject player;
    public Vector3 goalPos = Vector3.zero;

    [Header("NPC Settings")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public float neighbourDistance;
    [Range(1.0f, 5.0f)]
    public float rotationSpeed;

    void Start()
    {
        allNpc = new GameObject[numNpc];
        for(int i = 0; i < numNpc; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.RandomRange(-limits.x, limits.x), 0, Random.RandomRange(-limits.z, limits.z));
            allNpc[i] = Instantiate(Npc, pos, Quaternion.identity);
        }
        FM = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) // Ensure player GameObject is found
        {
            goalPos = player.transform.position;
        }
    }
}

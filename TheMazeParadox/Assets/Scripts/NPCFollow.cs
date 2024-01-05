using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCFollow : MonoBehaviour
{
    public Transform target; // Assign your main character's transform here
    public float stoppingDistance = 2f; // The distance at which the NPC will stop following

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stoppingDistance;
    }

    void Update()
    {
        // Check the distance to the target
        float distanceToTarget = Vector3.Distance(target.position, transform.position);

        // If the target is farther away than the stopping distance, move towards the target
        if (distanceToTarget > stoppingDistance)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            // If within stopping distance, stop moving
            agent.ResetPath();
        }
    }

    // Call this method to start following the main character
    public void StartFollowing()
    {
        enabled = true;
    }

    // Call this method to stop the NPC from following (e.g., when the cutscene ends)
    public void StopFollowing()
    {
        enabled = false;
        agent.ResetPath();
    }
}

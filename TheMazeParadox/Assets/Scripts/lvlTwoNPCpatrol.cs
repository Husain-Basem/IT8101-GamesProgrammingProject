using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class lvlTwoNPCpatrol : MonoBehaviour
{
    public Transform[] waypoints;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private bool isPatrolling;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        // Start patrolling immediately when the level loads
        StartPatrol();
    }

    private void GotoNextPoint()
    {
        if (waypoints.Length == 0)
            return;

        agent.destination = waypoints[destPoint].position;

        destPoint = (destPoint + 1) % waypoints.Length;
    }

    void Update()
    {
        if (isPatrolling && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }

    // Public method to start patrolling
    public void StartPatrol()
    {
        isPatrolling = true;
        GotoNextPoint();
    }

    // Public method to stop patrolling
    public void StopPatrol()
    {
        isPatrolling = false;
        agent.ResetPath();
    }
}

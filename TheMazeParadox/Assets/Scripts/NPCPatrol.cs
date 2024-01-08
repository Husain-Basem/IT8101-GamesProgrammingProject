using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPatrol : MonoBehaviour
{
     public Transform[] waypoints;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private bool isPatrolling;
    public Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); 
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

        // Check the agent's velocity to determine if it's currently moving
            //bool isMoving = agent.velocity.magnitude > 0.1f;
            //animator.SetBool("IsWalking", isMoving); // Set the IsWalking parameter in the Animator
    }

    // Public method to start patrolling
    public void StartPatrol()
    {
        isPatrolling = true;
        animator.SetBool("IsWalking", true);
        GotoNextPoint();
    }

    // Public method to stop patrolling
    public void StopPatrol()
    {
        isPatrolling = false;
        agent.ResetPath();
    }
}

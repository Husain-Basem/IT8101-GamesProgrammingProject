using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCFollow : MonoBehaviour
{
    private Transform target; 
    public float stoppingDistance; // The distance at which the NPC will stop following
    public Animator animator; 

    private NavMeshAgent agent;
    private bool isFollowing = false; // a flag to control the following behavior

    void Start()
{
    agent = GetComponent<NavMeshAgent>();
    agent.stoppingDistance = stoppingDistance;

    if (animator == null)
    {
        animator = GetComponent<Animator>();
    }

    // Find the active main character in the scene and set it as the target
    GameObject[] potentialTargets = GameObject.FindGameObjectsWithTag("Player");
    foreach (var potentialTarget in potentialTargets)
    {
        if (potentialTarget.activeInHierarchy)
        {
            target = potentialTarget.transform;
            break;
        }
    }

    // If no active main character was found, log a warning
    if (target == null)
    {
        Debug.LogWarning("NPCFollow: No active main character found.");
    }

    this.enabled = false; // the script starts with following disabled
}

    void Update()
    {
        if (isFollowing)
        {
            float distanceToTarget = Vector3.Distance(target.position, transform.position);

            if (distanceToTarget >= stoppingDistance)
            {
                agent.isStopped = false;
                agent.SetDestination(target.position);
                animator.SetBool("IsWalking", true);
            }
            else
            {
                // Stop the agent from moving
                if (!agent.isStopped) agent.isStopped = true;
                animator.SetBool("IsWalking", false);
            }
        }
    }

    public void StartFollowing()
    {
        isFollowing = true;
        this.enabled = true;
    }

    public void StopFollowing()
    {
        isFollowing = false;
        this.enabled = false;
        agent.isStopped = true; // Ensure the agent is stopped.
        animator.SetBool("IsWalking", false);
    }

}

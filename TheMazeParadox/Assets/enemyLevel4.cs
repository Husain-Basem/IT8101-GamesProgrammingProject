using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class enemyLevel4 : MonoBehaviour
{
    public NavMeshAgent ai;         // Reference to the NavMeshAgent component
    public Transform player;         // Reference to the player's transform
    public float sightRange = 10f;    // Range at which the enemy can detect the player
    public float attackRange = 2f;    // Range at which the enemy can attack the player

    private bool playerInSightRange;    // Flag indicating if the player is within sight range
    private bool playerInAttackRange;   // Flag indicating if the player is within attack range
    private Vector3 patrolDestination;   // The destination for patrolling

    Animator animator;  // Reference to the Animator component for animations


    // Called when the script starts
    private void Start()
    {
        // Initialize patrol destination when the script starts
        SetRandomPatrolDestination();

        // Get reference to the Animator component
        animator = GetComponent<Animator>();
    }

    // Called every frame
    private void Update()
    {
        // Check if the player is within sight or attack range
        CheckSightRange();
        CheckAttackRange();

        // Act based on player proximity
        if (playerInAttackRange && !player.CompareTag("Invisible"))
        {
            AttackPlayer();
        }
        else if (playerInSightRange && !player.CompareTag("Invisible"))
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    // Check if the player is within sight range
    private void CheckSightRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        playerInSightRange = distanceToPlayer <= sightRange;
    }

    // Check if the player is within attack range
    private void CheckAttackRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        playerInAttackRange = distanceToPlayer <= attackRange;
    }

    // Move towards the player when in sight range
    private void ChasePlayer()
    {
        ai.destination = player.position;
    }

    // Execute attack logic when the player is in attack range
    private void AttackPlayer()
    {
        // Your attack logic goes here
        // For demonstration purposes, we trigger an "Attack" animation and print a message to the console
        //animator.SetTrigger("Attack"); 
        Debug.Log("Hit");
        SceneManager.LoadScene("DeathScene-Level-4");
    }

    // Patrol by setting a new random destination if the enemy has reached the current destination
    private void Patrol()
    {
        // Check if the enemy has reached the patrol destination
        if (!ai.pathPending && ai.remainingDistance < 0.5f)
        {
            // Set a new random patrol destination
            SetRandomPatrolDestination();
        }
    }

    // Set a new random patrol destination within the patrol area
    private void SetRandomPatrolDestination()
    {
        patrolDestination = Random.insideUnitSphere * 10f; // Adjust 10f based on your patrol area size
        NavMeshHit hit;
        NavMesh.SamplePosition(patrolDestination, out hit, 10f, NavMesh.AllAreas);
        ai.destination = hit.position;
    }
}

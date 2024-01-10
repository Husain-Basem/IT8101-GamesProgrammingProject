using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class enemyWithStates : MonoBehaviour
{
    public NavMeshAgent ai;         // Reference to the NavMeshAgent component
    public Transform player;         // Reference to the player's transform
    public float sightRange = 10f;    // Range at which the enemy can detect the player
    public float attackRange = 2f;    // Range at which the enemy can attack the player

    private bool playerInSightRange;    // Flag indicating if the player is within sight range
    private bool playerInAttackRange;   // Flag indicating if the player is within attack range
    private Vector3 patrolDestination;   // The destination for patrolling
    private enum PatrolDirection
    {
        Forward,
        Backward,
        Left,
        Right
    }
    private PatrolDirection currentPatrolDirection;  // The current patrol direction

    public string sceneName;
    public float jumpscareTime;

    Animator animator;  // Reference to the Animator component for animations
    public Animator jumpscareAnim;

    public GameObject monsterWalking;
    public GameObject monsterSound;

    // Called when the script starts
    private void Start()
    {
        // Initialize patrol destination and direction when the script starts
        SetRandomPatrolDestination();
        SetRandomPatrolDirection();

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
        if (playerInAttackRange)
        {
            AttackPlayer();
        }
        else if (playerInSightRange)
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
        // For demonstration purposes, trigger on "Attack" animation and print a message to the console
        //animator.SetTrigger("Attack"); 
        monsterWalking.SetActive(false);
        monsterSound.SetActive(true);
        jumpscareAnim.SetTrigger("Jumpscare");
        Debug.Log("Hit");
        StartCoroutine(jumpscare());
    }
    IEnumerator jumpscare()
    {
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(sceneName);
    }

    // Patrol by setting a new random destination if the enemy has reached the current destination
    private void Patrol()
    {
        // Check if the enemy has reached the patrol destination
        if (!ai.pathPending && ai.remainingDistance < 0.5f)
        {
            // Set a new random patrol direction
            SetRandomPatrolDirection();

            // Set a new random patrol destination based on the direction
            SetRandomPatrolDestination();
        }
    }

    // Set a new random patrol direction
    private void SetRandomPatrolDirection()
    {
        // Choose a random direction from the PatrolDirection enum
        currentPatrolDirection = (PatrolDirection)Random.Range(0, System.Enum.GetValues(typeof(PatrolDirection)).Length);
    }

    // Set a new random patrol destination within the patrol area
    private void SetRandomPatrolDestination()
    {
        // Adjust patrolDestination based on the chosen patrol direction
        switch (currentPatrolDirection)
        {
            case PatrolDirection.Forward:
                patrolDestination = transform.position + transform.forward * Random.Range(5f, 10f);
                break;

            case PatrolDirection.Backward:
                patrolDestination = transform.position - transform.forward * Random.Range(5f, 10f);
                break;

            case PatrolDirection.Left:
                patrolDestination = transform.position - transform.right * Random.Range(5f, 10f);
                break;

            case PatrolDirection.Right:
                patrolDestination = transform.position + transform.right * Random.Range(5f, 10f);
                break;

            default:
                break;
        }

        // Declare a NavMeshHit variable to store information about the sampled position on the NavMesh
        NavMeshHit hit;

        // Sampling a valid position on the NavMesh near the generated destination within a radius of 10 units
        // The sampled position will be stored in the 'hit' variable
        NavMesh.SamplePosition(patrolDestination, out hit, 10f, NavMesh.AllAreas);

        // Set the AI's destination to the sampled position on the NavMesh
        ai.destination = hit.position;
    }
}

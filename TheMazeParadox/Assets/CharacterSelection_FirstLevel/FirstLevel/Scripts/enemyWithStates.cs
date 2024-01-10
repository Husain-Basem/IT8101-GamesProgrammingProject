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

    public string sceneName;
    public float jumpscareTime;

    Animator animator;  // Reference to the Animator component for animations
    public Animator jumpscareAnim;

    public GameObject monsterWalking;
    public GameObject monsterSound;

    [Header("Wall Avoidance Settings")]
    [Range(1.0f, 10.0f)]
    public float wallDetectionDistance; // Distance at which NPCs detect walls
    [Range(1.0f, 10.0f)]
    public float maxWallDistance; // Maximum distance to a wall before making a turn

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
            // Set a new random patrol destination
            SetRandomPatrolDestination();
        }
    }

    // Set a new random patrol destination within the patrol area
    private void SetRandomPatrolDestination()
    {
        RaycastHit rayhit;
        if (Physics.Raycast(transform.position, transform.forward, out rayhit, FlockManager.FM.wallDetectionDistance))
        {
            // If the ray hits a wall, change rotation based on wall distance
            float wallDistance = rayhit.distance;
            float maxRotationAngle = 90.0f; // You can adjust this value

            // Calculate a rotation angle based on the wall distance
            float rotationAngle = Mathf.Clamp(wallDistance / FlockManager.FM.maxWallDistance, 0f, 1f) * maxRotationAngle;

            // Apply the rotation to avoid the wall
            Quaternion avoidanceRotation = Quaternion.Euler(0, Random.Range(-rotationAngle, rotationAngle), 0);
            transform.rotation *= avoidanceRotation;
        }
        else
        {
            patrolDestination = Random.insideUnitSphere * 10f;
            NavMeshHit hit;
            NavMesh.SamplePosition(patrolDestination, out hit, 10f, NavMesh.AllAreas);
            ai.destination = hit.position;
        }
    }
}

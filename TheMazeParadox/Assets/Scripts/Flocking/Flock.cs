using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define a class for managing a flock of agents in Unity.
public class Flock : MonoBehaviour
{
    // Prefab for individual flock agents.
    public FlockAgent agentPrefab;

    // List to store references to the flock agents.
    List<FlockAgent> agents = new List<FlockAgent>();

    // Reference to the flock behavior.
    public FlockBehaviour behaviour;

    // Reference to the GameObject representing the spawn point for the flock.
    public GameObject spawn;

    // Parameters for configuring the flock.
    [Range(1, 10)]
    public int startingCount = 5;
    const float AgentDensity = 0.08f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRediusMultiplier = 0.5f;

    // Variables for squared values of parameters.
    float squareMaxSpeed;
    float SquareNeighborRadius;
    float squareAvoidanceRadius;

    // Public property to access the squared avoidance radius from other scripts.
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    // Start is called before the first frame update
    void Start()
    {
        // Check if the reference to the spawn point is set
        if (spawn != null)
        {
            // Calculate squared values for parameters.
            squareMaxSpeed = maxSpeed * maxSpeed;
            SquareNeighborRadius = neighborRadius * neighborRadius;
            squareAvoidanceRadius = SquareNeighborRadius * avoidanceRediusMultiplier * avoidanceRediusMultiplier;

            // Set the position to the spawn point's position.
            Vector3 spawnPosition = spawn.transform.position;

            // Instantiate flock agents based on the starting count.
            for (int i = 0; i < startingCount; i++)
            {
                // Generate a random rotation only around the Y-axis.
                Quaternion randomYRotation = Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 0f));

                // Instantiate a new flock agent.
                FlockAgent newAgent = Instantiate(
                    agentPrefab,
                    spawnPosition,
                    randomYRotation,
                    transform
                );

                // Set a unique name for the agent.
                newAgent.name = "Agent " + i;
                newAgent.Initialize(this);

                // Add the agent to the list of flock agents.
                agents.Add(newAgent);
            }
        }
        else
        {
            // Display an error if the spawn point reference is not set.
            Debug.LogError("Spawn point reference not set. Please assign the spawn point in the Unity Editor.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (FlockAgent agent in agents) {
            List<Transform> context = GetNearbybyObjects(agent);

            Vector3 move = behaviour.CalculateMove(agent, context, this);
            move *= driveFactor;
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
        }
    }
    List<Transform> GetNearbybyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighborRadius);
        foreach(Collider c in contextColliders)
        {
            if (c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }
}

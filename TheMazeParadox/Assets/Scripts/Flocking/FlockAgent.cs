using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ensure that this script requires a Collider component to be attached to the same GameObject.
[RequireComponent(typeof(Collider))]
public class FlockAgent : MonoBehaviour
{
    Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }
    // Reference to the Collider component attached to this GameObject.
    Collider agentCollider;

    // Public property to access the agent's collider from other scripts.
    public Collider AgentCollider { get { return agentCollider; } }

    // Start is called before the first frame update
    void Start()
    {
        // Get the Collider component attached to this GameObject.
        agentCollider = GetComponent<Collider>();
    }

    public void Initialize(Flock flock)
    {
        agentFlock = flock;
    }

    // Public method to move the agent based on a provided velocity.
    public void Move(Vector3 velocity)
    {
        // Align the agent's forward direction with the provided velocity.
        transform.forward = velocity;

        // Move the agent's position based on the velocity and the time passed since the last frame.
        transform.position += velocity * Time.deltaTime;
    }
}


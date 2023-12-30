using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define an abstract class for flock behaviors as a ScriptableObject in Unity.
public abstract class FlockBehaviour : ScriptableObject
{
    // Abstract method to be implemented by subclasses.
    // Calculates and returns the desired movement for a flock agent.
    // Parameters:
    //   agent: The individual agent for which the movement is being calculated.
    //   context: A list of Transform objects representing the agents or elements in the environment that influence the calculation.
    //   flock: A reference to the overall flock, which may contain additional information or parameters.
    public abstract Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock);
}


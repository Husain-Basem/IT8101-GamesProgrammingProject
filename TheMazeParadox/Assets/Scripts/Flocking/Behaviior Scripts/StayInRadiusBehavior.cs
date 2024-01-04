using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Stay In Radius")]
public class StayInRadiusBehavior : FlockBehaviour
{
    public float radius = 15f;
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector3 centerOffset = flock.spawn.transform.position - agent.transform.position;
        float t = centerOffset.magnitude / radius;
        if (t < 0.9f)
        {
            return Vector3.zero;
        }
        return centerOffset * t * t;
    }
}
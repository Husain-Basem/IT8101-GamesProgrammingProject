using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    float speed; // Current speed of the NPC

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the speed of the NPC to a random value within the specified range
        speed = Random.Range(FlockManager.FM.minSpeed, FlockManager.FM.maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Apply flocking rules and move the NPC
        ApplyRules();
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }

    // Method to apply flocking rules
    void ApplyRules()
    {
        GameObject[] gos;
        gos = FlockManager.FM.allNpc;

        Vector3 vcenter = Vector3.zero; // Center of the flock
        Vector3 vavoid = Vector3.zero; // Avoidance vector
        float gSpeed = 0.01f; // Group speed
        float nDistance; // Distance to other NPCs
        int groupSize = 0; // Number of nearby NPCs in the group

        foreach (GameObject go in gos)
        {
            if (go != this.gameObject)
            {
                // Calculate the distance between this NPC and another NPC
                nDistance = Vector3.Distance(go.transform.position, this.transform.position);

                if (nDistance <= FlockManager.FM.neighbourDistance)
                {
                    vcenter += go.transform.position;
                    groupSize++;

                    // If the distance is very close, add an avoidance vector
                    if (nDistance < 1.0f)
                    {
                        vavoid += (this.transform.position - go.transform.position);
                    }

                    // Get the Flock component of the other NPC and accumulate group speed
                    Flock anotherFlock = go.GetComponent<Flock>();
                    gSpeed += anotherFlock.speed;
                }
            }
        }

        if (groupSize > 0)
        {
            // Calculate the center of the flock and adjust speed
            vcenter = (vcenter / groupSize) + (FlockManager.FM.goalPos - this.transform.position);
            speed = gSpeed / groupSize;

            // Clamp the speed to the maximum speed defined in FlockManager
            if (speed > FlockManager.FM.maxSpeed)
                speed = FlockManager.FM.maxSpeed;

            // Calculate the direction based on the center and avoidance vectors
            Vector3 direction = (vcenter + vavoid) - transform.position;

            // If there is a direction vector, rotate towards it
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), FlockManager.FM.rotationSpeed * Time.deltaTime);
        }
    }
}

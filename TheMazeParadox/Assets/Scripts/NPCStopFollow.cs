using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStopFollow : MonoBehaviour
{
    public NPCFollow npcFollowScript;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            npcFollowScript.StopFollowing();
        }
    }
}

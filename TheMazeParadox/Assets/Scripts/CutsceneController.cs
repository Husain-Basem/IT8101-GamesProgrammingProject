using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneController : MonoBehaviour
{
     public PlayableDirector director;
    public NPCFollow npcFollowScript;
    public NPCPatrol npcPatrolScript; // Reference to the NPC's patrol script

    void OnEnable()
    {
        director.played += OnCutscenePlayed;
        director.stopped += OnCutsceneStopped;
    }

    void OnDisable()
    {
        director.played -= OnCutscenePlayed;
        director.stopped -= OnCutsceneStopped;
    }

    private void OnCutscenePlayed(PlayableDirector aDirector)
    {
        if (aDirector == director)
        {
            // Stop the patrol when the cutscene starts
            npcPatrolScript.StopPatrol();
        }
    }

    private void OnCutsceneStopped(PlayableDirector aDirector)
    {
        if (aDirector == director)
        {
            // Start following the player after the cutscene
            npcFollowScript.StartFollowing();

            // If you want to resume patrol after following (at some point), 
            // you can call npcPatrolScript.StartPatrol() when appropriate.
        }
    }
}

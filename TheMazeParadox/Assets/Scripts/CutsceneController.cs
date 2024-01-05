using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneController : MonoBehaviour
{
     public PlayableDirector director;
    public NPCFollow npcFollowScript;

    void OnEnable()
    {
        director.stopped += OnCutsceneStopped;
    }

    void OnDisable()
    {
        director.stopped -= OnCutsceneStopped;
    }

    private void OnCutsceneStopped(PlayableDirector aDirector)
    {
        if (aDirector == director)
        {
            npcFollowScript.StartFollowing();
        }
    }
}

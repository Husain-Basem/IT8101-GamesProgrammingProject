using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyChase : MonoBehaviour
{
    public NavMeshAgent ai;
    public Transform player;
    Vector3 dest;

    private void Update()
    {
        
        dest = player.position;
        ai.destination = dest;
        
    }
}

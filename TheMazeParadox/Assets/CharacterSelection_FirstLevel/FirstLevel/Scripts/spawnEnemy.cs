using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class spawnEnemy : MonoBehaviour
{
    public GameObject enemy, wall1, wall2, wall3;
    public Collider collision;
    public bool walls;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.SetActive(true);
            if(walls == true)
            {
                wall1.SetActive(true);
                wall2.SetActive(true);
                wall3.SetActive(false);
            }
            collision.enabled = false;
        }
    }
}

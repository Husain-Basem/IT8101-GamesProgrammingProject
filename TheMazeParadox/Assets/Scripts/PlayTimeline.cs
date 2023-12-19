using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class box : MonoBehaviour
{
    // timeline variable
    [SerializeField]
    private PlayableDirector timelineCinematic;
    [SerializeField]
    private GameObject keyItem;
    [SerializeField]
    private GameObject lanternTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (keyItem.activeSelf == false)
        {
            timelineCinematic.Play();
            Debug.Log("Player can pass the tree");
            lanternTrigger.SetActive(false);
        }
    }
}

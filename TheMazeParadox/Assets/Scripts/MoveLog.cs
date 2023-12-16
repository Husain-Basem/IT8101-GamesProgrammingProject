using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLog : MonoBehaviour
{

    //variables
    public GameObject Log;
    public GameObject LogDestination;
    public float speed; // set speed of moving log
    [SerializeField]
    GameObject keyItem;
    [SerializeField]
    float rotateSpeed; // used to set the rotation speed of the log
    [SerializeField]
    Vector3 rotationDirection = new Vector3();
    private bool moveLog = false;

    // Update is called once per frame
    void Update()
    {
        if (moveLog == true)
        {
            // move the log to the position of the empty object
            Log.transform.position = Vector3.MoveTowards(Log.transform.position, LogDestination.transform.position, speed);
            Log.transform.Rotate(rotateSpeed * rotationDirection * Time.deltaTime);

            if (Log.transform.position.x == LogDestination.transform.position.x)
            {
                moveLog = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (keyItem.activeSelf == false)
        {
            moveLog = true;
        }
        
    }
}

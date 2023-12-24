using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtScan : MonoBehaviour
{

    [SerializeField]
    GameObject objectToLook;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(objectToLook.transform);
    }
}

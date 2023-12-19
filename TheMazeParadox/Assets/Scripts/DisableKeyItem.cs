using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableKeyItem : MonoBehaviour
{
    [SerializeField]
    GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        key.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleLight : MonoBehaviour
{

    public GameObject Spotlight, Flame;
    public AudioSource toggleSound;

    public bool onOff;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (onOff)
        {
            Spotlight.SetActive(true);
            Flame.SetActive(true);
        }
        else {
            Spotlight.SetActive(false);
            Flame.SetActive(false);
        }
        toggle();
    }

    public void toggle ()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            onOff = !onOff;
        }
    }
}

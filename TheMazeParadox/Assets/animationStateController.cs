using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    // variables
    Animator animator;
    int isRunningHash;
    string[] keys = new string[] { "a", "w", "s", "d" };
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool keyPressed = AnyKeyDown(keys);
        if (!isRunning && keyPressed)
        {
            animator.SetBool(isRunningHash, true);
        }

        if (isRunning && !keyPressed)
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    // check if any of wasd keys were pressed
    private bool AnyKeyDown(IEnumerable<string> keys)
    {
        foreach (string key in keys)
        {
            if (Input.GetKey(key)) return true;
        }
        return false;
    }
}

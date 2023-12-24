using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    // variables
    Animator animator;
    int isRunningHash;
    int isJumpingHash;
    int isFallingHash;
    int isGroundedHash;

    string[] keys = new string[] { "a", "w", "s", "d" };
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
        isFallingHash = Animator.StringToHash("isFalling");
        isGroundedHash = Animator.StringToHash("isGrounded");
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = ThirdPersonMovement.instance.isGrounded;
        bool isJumping = ThirdPersonMovement.instance.isJumping;
        bool isRunning = animator.GetBool(isRunningHash);
        bool keyPressed = AnyKeyDown(keys);
        
        animator.SetBool(isGroundedHash, isGrounded);
        animator.SetBool(isJumpingHash, isJumping);

        if (!isGrounded && !isJumping)
        {
            animator.SetBool(isFallingHash, true);
        }

        if (!isJumping)
        {
            animator.SetBool(isFallingHash, true);
        }

        if (isGrounded)
        {   
            animator.SetBool(isFallingHash, false);
        }

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

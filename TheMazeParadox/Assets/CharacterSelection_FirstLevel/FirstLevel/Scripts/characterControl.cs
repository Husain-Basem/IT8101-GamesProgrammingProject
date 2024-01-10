using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class characterControl : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public Camera playerCamera2;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    // Animator variables
    public Animator animator;
    public Animator animator2;

    public Animator animatorR;
    public Animator animatorR2;


    public string jumpTrigger = "Jump";
    public string walkTrigger = "Walk";
    public string runTrigger = "Run";
    public string idleTrigger = "Idle";

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Trigger the idle animation as the default state
        animator.SetTrigger(idleTrigger);
        animator2.SetTrigger(idleTrigger);

        animatorR.SetTrigger(idleTrigger);
        animatorR2.SetTrigger(idleTrigger);
    }

    private void Update()
    {
        // Character grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            // Trigger jump animation
            animator.SetTrigger(jumpTrigger);
            animator2.SetTrigger(jumpTrigger);

            animatorR.SetTrigger(jumpTrigger);
            animatorR2.SetTrigger(jumpTrigger);
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Applying gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            playerCamera2.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        // Update animator based on movement
        UpdateAnimator(isRunning, curSpeedX);
    }

    // Update the animator based on movement parameters
    private void UpdateAnimator(bool isRunning, float speed)
    {
        // Set animator parameters based on movement
        animator.SetBool(walkTrigger, speed > 0 && !isRunning);
        animator.SetBool(runTrigger, isRunning && speed > 0);
        animator.SetBool(idleTrigger, speed == 0);

        animator2.SetBool(walkTrigger, speed > 0 && !isRunning);
        animator2.SetBool(runTrigger, isRunning && speed > 0);
        animator2.SetBool(idleTrigger, speed == 0);

        animatorR.SetBool(walkTrigger, speed > 0 && !isRunning);
        animatorR.SetBool(runTrigger, isRunning && speed > 0);
        animatorR.SetBool(idleTrigger, speed == 0);

        animatorR2.SetBool(walkTrigger, speed > 0 && !isRunning);
        animatorR2.SetBool(runTrigger, isRunning && speed > 0);
        animatorR2.SetBool(idleTrigger, speed == 0);
    }
}

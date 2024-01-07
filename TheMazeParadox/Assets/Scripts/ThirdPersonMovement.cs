using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonMovement : MonoBehaviour
{
    public static ThirdPersonMovement instance;

    public CharacterController controller;
    private Rigidbody rb;
    Animator animator;
    public Transform cam;

    public float speed = 6f;
    public float fallingThreshHold = -0.001f;
    [HideInInspector]
    public bool isFalling = false;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Time jumpTimer;

    public bool isJumping = false;
    [SerializeField] public bool isGrounded = false;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    private Vector3 velocity;

    [SerializeField] private float jumpHeight;

    float timePassed = 0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        // set true if character is on ground, otherwise set to false
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horzontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horzontal, 0f, vertical).normalized;

        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            timePassed += Time.deltaTime;
            if (timePassed > 0.38f && isGrounded)
            {
                FindObjectOfType<AudioManager>().Play("Walking");
                timePassed = 0f;
            }
            

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            
        }

        velocity.y += gravity * Time.deltaTime; // calculate gravity
        controller.Move(velocity * Time.deltaTime); // apply gravity to the character

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        FindObjectOfType<AudioManager>().Play("Jump");
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
}

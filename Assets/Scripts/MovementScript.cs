using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class MovementScript : MonoBehaviour
{

    private Rigidbody rb;
    public LayerMask groundLayer;
    public float groundDistance;
    public float groundCheckRadius;
    public bool isGrounded = false;
    public float jumpFlag = 0;
    public Transform ori;
    private float horizontal;
    [SerializeField] private float crouchMultiplier = 0.5f;
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float runMultiplier = 2;
    [SerializeField] private float maxSpeed = 0;
    [SerializeField] private float jumpForce = 0;
    private float vertical;
    private const float gravity = 9.81f;
    private Vector3 direction;
    private bool run = false;
    [SerializeField] private float dragForce = 5;
    private float brakeSpeed;
    public enum MovementActions
    {
        Idle,
        Walking,
        Running,
        Crouching
    }

    public MovementActions movementAction = MovementActions.Idle;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.freezeRotation = true; rb.useGravity = false; rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous; rb.drag = 1;
        }

    }
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space)) jumpFlag = (float)0.1 / Time.fixedDeltaTime;

        if(vertical != 0 || horizontal != 0)
        {
            movementAction = MovementActions.Walking;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                movementAction = MovementActions.Running;
            }
        }
        else
        {
            movementAction = MovementActions.Idle;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            movementAction = MovementActions.Crouching;
        }


        run = Input.GetKey(KeyCode.LeftShift);
       


        
    }
    void FixedUpdate()
    {

       
        rb.AddForce(Vector3.down * gravity, ForceMode.Force);
        Move(speed, maxSpeed, isGrounded);
        Jump();


    }

    private void Move(float speed, float maxSpeed, bool grounded, float baseSpeed = 10f)
    {
        direction = transform.forward * vertical + transform.right * horizontal;
        float movementMultiplier = 1;

        if (movementAction == MovementActions.Running)
        {
            movementMultiplier = runMultiplier;
        }

        if (movementAction == MovementActions.Crouching)
        {
            movementMultiplier = crouchMultiplier;
        }

        if (!grounded)
        {
            baseSpeed /= 2;
            maxSpeed /= 4;
            movementMultiplier = movementMultiplier > 1 ? 1 : movementMultiplier;
        }


       
        




        float rbSpeed = Vector3.Magnitude(rb.velocity);
        if (rbSpeed > maxSpeed)
        {
            brakeSpeed = rbSpeed - maxSpeed;

            Vector3 normalisedVelocity = rb.velocity.normalized;
            Vector3 brakeVelo = normalisedVelocity * brakeSpeed;
            rb.AddForce(-brakeVelo, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(baseSpeed * movementMultiplier * speed * direction.normalized, ForceMode.Force);
        }

    }

    private void Jump()
    {
        // Use Physics.SphereCast to check if the player is grounded
        isGrounded = Physics.SphereCast(transform.position, groundCheckRadius, Vector3.down, out RaycastHit hit, groundDistance, groundLayer);
        rb.drag = isGrounded ? dragForce : 0.01f;
        if (isGrounded)
        {
            if (jumpFlag > 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                jumpFlag = 0;
            }
        }
        if (jumpFlag > 0) jumpFlag--;
    }
}

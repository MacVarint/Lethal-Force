using UnityEngine;

public class CharacterController : MonoBehaviour

{
    // Movement speed
    public float moveSpeed = 5f;

    // Reference to the character's rigidbody
    private Rigidbody rb;

    // The sensitivity of the mouse
    public float mouseSensitivity = 2.0f;

    // The minimum and maximum angles that the player can look up and down
    public Vector2 pitchMinMax = new Vector2(-40, 85);

    // The current rotation of the player
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public float horizontalInput;
    public float verticalInput;
    float mouseX;

    public Camera camera;

    // Use this for initialization
    void Start()
    {
        // Get a reference to the character's rigidbody
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        Rotation();
    }

    private void FixedUpdate()
    {
        Movement();
    }
    private void Inputs()
    {
        // Get the horizontal and vertical input axes
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        // Get the mouse delta
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
    }
    public void Movement()
    {
        // Calculate the movement vector
        Vector3 movement = verticalInput * this.transform.forward + horizontalInput * this.transform.right;
        movement = movement.normalized;

        // Move the character in the direction of the input
        rb.MovePosition(this.transform.position + movement * moveSpeed * Time.deltaTime);
    }
    public void Rotation()
    {
        // Update the player's yaw (left/right rotation) and pitch (up/down rotation)
        yaw += mouseX;

        // Clamp the pitch within the min/max range
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        // Rotate the player
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }
}

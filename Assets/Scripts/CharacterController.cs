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
        Movement();
        Mouse();
    }
    public void Movement()
    {
        // Get the horizontal and vertical input axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        // Move the character in the direction of the input
        rb.MovePosition(this.transform.position + movement * moveSpeed * Time.deltaTime);
    }
    public void Mouse()
    {
        // Get the mouse delta
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Update the player's yaw (left/right rotation) and pitch (up/down rotation)
        yaw += mouseX;
        pitch -= mouseY;

        // Clamp the pitch within the min/max range
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        // Rotate the player
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}

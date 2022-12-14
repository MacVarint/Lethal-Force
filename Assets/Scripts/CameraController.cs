using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraSnapPoint;

    // The sensitivity of the mouse
    public float mouseSensitivity = 2.0f;

    // The minimum and maximum angles that the player can look up and down
    public Vector2 pitchMinMax = new Vector2(-40, 85);

    // The current rotation of the player
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mouse();
    }
    private void FixedUpdate()
    {
        transform.position = cameraSnapPoint.transform.position;
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

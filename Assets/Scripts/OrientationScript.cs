using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationScript : MonoBehaviour
{
    [SerializeField] public Transform orientation;
    [SerializeField] private float sensitivity = 100f;
    [SerializeField] public GameObject cam;
    [SerializeField] public CameraScript camScript;

    //[SerializeField] private Transform arm;

    [SerializeField] private Vector3 oriented = new(0, 0, 0);

    private float xRotation = 0f;
    private float yRotation = 0f;
    public Vector2 mouseDelta { get; private set; }

    private void Awake()
    {
        orientation = transform.Find("Orientation");
        //arm = transform.Find("RightShoulder");
    }

    private void Start()
    {
            camScript = cam.GetComponent<CameraScript>();
    }

    private void Update()
    {


        float mouseX = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;
        mouseDelta = new Vector2(mouseX, mouseY);

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(0, yRotation, 0);
        orientation.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        cam.transform.SetPositionAndRotation(transform.position, orientation.rotation);
        camScript.Camera();
        //arm.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        //arm.rotation = Quaternion.Euler(xRotation, yRotation, 0);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [SerializeField] private GameObject target;
    private Transform targetOrientation;
    private Transform targetViewPosition;
    [SerializeField] private float FOV = 60;
    private Camera cam;
    private Vector2 mouseDelta;


    public enum CameraMode
    {
        FirstPerson, ThirdPerson
    }

    [SerializeField] private CameraMode cameraMode;

    private void Start()
    {
        cam = GetComponent<Camera>();
        targetOrientation = target.transform.Find("Orientation");
        targetViewPosition = target.transform.Find("CameraPos");

    }

    public void Camera()
    {
        cam.fieldOfView = FOV;
        if (cameraMode == CameraMode.FirstPerson)
        {
            try
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                cam.transform.SetPositionAndRotation(targetViewPosition.position, targetOrientation.rotation);



            }
            catch (System.Exception)
            {
                Debug.LogError("Could not move camera to the target.");
                throw;
            }
        }
    }
}

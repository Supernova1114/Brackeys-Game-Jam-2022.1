using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField]
    private Transform playerBody;
    [SerializeField]
    private CinemachineVirtualCamera vcam;

    public float mouseSens = 100f;
    float xRotate = 0;
    float yRotate = 0;

    void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.fixedDeltaTime;

        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate, -90f, 90);

        yRotate += mouseX;
        //yRotate = Mathf.Clamp(yRotate, -90f, 90);

        playerBody.Rotate(Vector3.up * mouseX);

        vcam.ForceCameraPosition(transform.position, Quaternion.Euler(xRotate, yRotate, 0));
    }
}

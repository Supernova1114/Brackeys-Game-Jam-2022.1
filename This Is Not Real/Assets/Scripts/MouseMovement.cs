using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] Transform playerBody;
    public float mouseSens = 100f;
    float xRotate = .0f;

    void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate, -90f, 90);

        playerBody.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotate, .0f, .0f);
    }
}

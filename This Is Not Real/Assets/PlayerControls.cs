using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private float mouseX;
    private float mouseY;

    [SerializeField]
    private float mouseSpeedX;
    [SerializeField]
    private float mouseSpeedY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Camera movement
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(0, mouseX, 0);


    }// void Update()
}

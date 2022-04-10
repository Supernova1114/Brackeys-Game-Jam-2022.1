using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    private float vertical;

    private Rigidbody rbody;

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float smoothTime = 0.2f;

    private Vector2 currentInputVector;
    private Vector2 smoothInputVelocity;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        Vector2 targetVelocity = transform.rotation * new Vector2(movement.x, movement.z);

        currentInputVector = Vector2.SmoothDamp(currentInputVector, targetVelocity, ref smoothInputVelocity, smoothTime);

        Vector3 newVelocity = new Vector3(currentInputVector.x, 0, currentInputVector.y).normalized * movementSpeed;
        newVelocity.y = rbody.velocity.y;

        rbody.velocity = newVelocity;


        //alskdjasdjawslkdjlskj
    }
}

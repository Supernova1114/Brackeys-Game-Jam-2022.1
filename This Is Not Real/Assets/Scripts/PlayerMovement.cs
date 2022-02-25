using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    private float vertical;

    private Rigidbody rbody;

    [SerializeField]
    private float moveSpeed;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        
    }

    private void FixedUpdate()
    {
        // transform.position += 
        Vector3 movement = transform.rotation * new Vector3(horizontal, 0, vertical) * moveSpeed;
        rbody.velocity = new Vector3(movement.x, rbody.velocity.y, movement.z);
    }
}

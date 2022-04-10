using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    private float vertical;
    private float mouseX;
    private float mouseY;

    private Rigidbody rbody;

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float smoothTime = 0.2f;

    private Vector2 currentInputVector;
    private Vector2 smoothInputVelocity;

    //--------------------------------------

    //Step sound cooldown
    [SerializeField]
    private float stepSoundCooldown;
    private float stepCooldown;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        currentInputVector = Vector2.zero;
        smoothInputVelocity = Vector2.zero;
        stepCooldown = 0;

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(horizontal, vertical).normalized;

        currentInputVector = Vector2.SmoothDamp(currentInputVector, movement, ref smoothInputVelocity, smoothTime);

        Vector3 newVelocity = transform.rotation * new Vector3(currentInputVector.x, 0, currentInputVector.y) * movementSpeed;
        newVelocity.y = rbody.velocity.y;

        rbody.velocity = newVelocity;

        PlayStepSound(movement);


    }


    void PlayStepSound(Vector2 movement)
    {
        if (movement.magnitude > 0)
        {
            if (stepCooldown <= 0)
            {
                int randNum = Random.Range(1, 5);
                AudioManager.instance.PlayOneShot("step" + randNum);

                stepCooldown = stepSoundCooldown;
            }
            else
            {
                stepCooldown -= Time.fixedDeltaTime;
            }
        }
        
    }

}

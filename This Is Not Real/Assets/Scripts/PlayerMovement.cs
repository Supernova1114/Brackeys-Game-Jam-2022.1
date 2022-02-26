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
    [SerializeField]
    private float stepSoundInterval;
    private float stepSoundCoolDown;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        stepSoundCoolDown = stepSoundInterval;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0)
        {
            if (stepSoundCoolDown <= 0)
            {
                int randomNum = Random.Range(0, 4);
                switch (randomNum)
                {
                    case 0: AudioManager.instance.PlayOneShot("step1"); break;
                    case 1: AudioManager.instance.PlayOneShot("step2"); break;
                    case 2: AudioManager.instance.PlayOneShot("step3"); break;
                    case 3: AudioManager.instance.PlayOneShot("step4"); break;
                }

                stepSoundCoolDown = stepSoundInterval;
            }
            else
            {
                stepSoundCoolDown -= Time.deltaTime;
            }
        }
        
        
    }

    private void FixedUpdate()
    {
        // transform.position += 
        Vector3 movement = transform.rotation * new Vector3(horizontal, 0, vertical) * moveSpeed;
        rbody.velocity = new Vector3(movement.x, rbody.velocity.y, movement.z);
    }
}

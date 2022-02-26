using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenTest : MonoBehaviour
{
    private Transform originalPlace;
    private bool shouldGravitate = false;
    private Rigidbody body;
    private Transform gravityPoint;
    float gravity = 9.8f;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        originalPlace = transform;
        gravityPoint = GameObject.Find("GravityPoint").transform;
        StartCoroutine("Begin");
    }

    IEnumerator Begin()
    {
        yield return new WaitForSeconds(3);
        iTween.PunchRotation(gameObject, new Vector3(2, 2, 2), 3);

        transform.position = originalPlace.position;
        transform.rotation = originalPlace.rotation;

        //body.constraints = RigidbodyConstraints.None; //RigidbodyConstraints.FreezeRotation;
        yield return new WaitForSeconds(6);
        GetComponent<Collider>().isTrigger = true;
        shouldGravitate = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (shouldGravitate)
        {
            body.AddForce((gravityPoint.transform.position - transform.position).normalized * gravity);
        }
    }
}

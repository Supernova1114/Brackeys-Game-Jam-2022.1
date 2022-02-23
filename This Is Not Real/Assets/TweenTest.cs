using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenTest : MonoBehaviour
{
    private Transform originalPlace;
    //private Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        //body = GetComponent<Rigidbody>();
        originalPlace = transform;
        StartCoroutine("Begin");
    }

    IEnumerator Begin()
    {
        yield return new WaitForSeconds(3);
        iTween.PunchRotation(gameObject, new Vector3(2, 2, 2), 3);

        transform.position = originalPlace.position;
        transform.rotation = originalPlace.rotation;

        //body.constraints = RigidbodyConstraints.None; //RigidbodyConstraints.FreezeRotation;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

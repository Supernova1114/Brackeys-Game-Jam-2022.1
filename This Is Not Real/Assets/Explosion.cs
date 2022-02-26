using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private float explosionRadius;
    [SerializeField]
    private float explosionForce;
    [SerializeField]
    LayerMask effectLayer;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("Explode");
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(6);
        Collider[] colliderList = Physics.OverlapSphere(transform.position, explosionRadius, effectLayer.value);
        
        foreach (Collider collider in colliderList)
        {
            if (collider.attachedRigidbody != null)
            {
                collider.attachedRigidbody.constraints = RigidbodyConstraints.None;
                collider.isTrigger = false;
                collider.attachedRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

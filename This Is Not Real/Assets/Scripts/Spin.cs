using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField]
    float xSpin;
    [SerializeField]
    float ySpin;
    [SerializeField]
    float zSpin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(xSpin, ySpin, zSpin);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.UI;

public class DemoDialing : MonoBehaviour
{
    [SerializeField] Text dial;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    
    private bool isInside = false;
    private bool oneShot = false;

    void Start()
    {
        dial.gameObject.SetActive(false);
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E) && isInside && !oneShot)
        {
            source.PlayOneShot(clip);
            oneShot = true;
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            dial.gameObject.SetActive(true);
            isInside = true;
        }    
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            dial.gameObject.SetActive(false);
            isInside = false;
        } 
    }
}


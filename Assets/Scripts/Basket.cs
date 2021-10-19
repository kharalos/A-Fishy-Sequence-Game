using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public AudioSource source;
    public bool objectIn;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other)
        {
            objectIn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other)
        {
            objectIn = false;
        }
    }
}

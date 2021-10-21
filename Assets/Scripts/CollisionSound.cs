using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().volume = GetComponent<Rigidbody>().velocity.magnitude;
        GetComponent<AudioSource>().Play();
    }
}

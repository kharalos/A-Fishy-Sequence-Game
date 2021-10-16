using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public GameObject target;
    Rigidbody body;
    Animator anim;
    private void Start()
    {
        body = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }
    void FixedUpdate()
    {
        body.velocity = target.transform.position - body.position;
        transform.LookAt(target.transform);
        anim.SetFloat("Swim", body.velocity.magnitude * 7);
    }
}

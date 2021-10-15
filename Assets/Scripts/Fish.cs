using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public GameObject target;
    Rigidbody body;
    Animator anim;
    public float distanceValue;
    private void Start()
    {
        body = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }
    void FixedUpdate()
    {
        body.MovePosition((body.position + (target.transform.position - body.position) * 0.2f * Time.deltaTime));
        transform.LookAt(target.transform);
        distanceValue = (target.transform.position - body.position).magnitude;
        anim.SetFloat("Swim", distanceValue);
    }
}

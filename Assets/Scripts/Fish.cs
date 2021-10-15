using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public GameObject target;
    Rigidbody body;
    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        body.MovePosition((body.position + (target.transform.position - body.position) * 0.2f * Time.deltaTime));
        transform.LookAt(target.transform);
    }
}

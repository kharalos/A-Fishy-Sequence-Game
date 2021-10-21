using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    protected bool holdable;
    protected bool holding;
    protected GameObject target;
    protected Rigidbody body;
    public virtual void Highlight()
    {

    }
    public virtual void Interaction()
    {
        if (holdable) 
        {
            target = GameObject.Find("HoldingTarget");
            body = gameObject.GetComponent<Rigidbody>();
            target.transform.position = body.position;
        }
    }
    public virtual void InteractionHold()
    {
        if (!holdable) return;
        holding = true;
        body.useGravity = false;

    }
    protected virtual void FixedUpdate()
    {
        if (holding && body && target) body.velocity = (target.transform.position - body.position) * 5;
        if (body && body.velocity.magnitude > 6) InteractionStop();
    }
    public virtual void InteractionStop()
    {
        holding = false;
        if(body)body.useGravity = true;
    }
}

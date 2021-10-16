using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : InteractableObject
{
    public enum DoorSide {left,right}
    public DoorSide doorSide;
    Animator anim;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    public override void Interaction()
    {
        base.Interaction();
        if(doorSide == DoorSide.left)
        {
            anim.SetTrigger("Left");
        }
        if (doorSide == DoorSide.right)
        {
            anim.SetTrigger("Right");
        }
    }

}

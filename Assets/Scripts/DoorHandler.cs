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

    protected override void Interaction()
    {
        base.Interaction();
        if(doorSide == DoorSide.left)
        {

        }
        if (doorSide == DoorSide.right)
        {

        }
    }

}

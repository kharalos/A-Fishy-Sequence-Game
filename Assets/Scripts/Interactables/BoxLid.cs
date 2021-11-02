using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLid : InteractableObject
{
    public override void Interaction()
    {
        base.Interaction();
        GetComponentInParent<BoxManager>().OpenBox();
    }
}

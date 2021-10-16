using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBall : InteractableObject
{
    public override void Interaction()
    {
        holdable = true;
        base.Interaction();
    }

}

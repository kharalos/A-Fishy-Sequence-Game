using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : InteractableObject
{
    public override void Interaction()
    {
        holdable = true;
        base.Interaction();
    }

}

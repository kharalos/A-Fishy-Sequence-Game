using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearFront : InteractableObject
{
    public MeshRenderer key;
    public override void Interaction()
    {
        if (FindObjectOfType<InventoryManager>().CheckItem("bearkey"))
        {
            FindObjectOfType<BearManager>().GetComponent<Animator>().SetTrigger("unlock");
            key.enabled = true;
            Destroy(this);
        }
    }
}

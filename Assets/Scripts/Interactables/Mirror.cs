using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : InteractableObject
{
    public override void Interaction()
    {
        if (GetComponent<Rigidbody>().isKinematic && FindObjectOfType<InventoryManager>().CheckItem("screwdriver"))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<AudioSource>().Play();
        }
    }
}

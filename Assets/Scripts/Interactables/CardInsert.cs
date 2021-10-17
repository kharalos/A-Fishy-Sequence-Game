using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInsert : InteractableObject
{
    public override void Interaction()
    {
        if (!FindObjectOfType<InventoryManager>().CheckItem("yellowcard")) return;
        FindObjectOfType<BearManager>().GetComponent<Animator>().SetTrigger("card");
        FindObjectOfType<BearManager>().cardInserted = true;
        Destroy(gameObject);
    }
}

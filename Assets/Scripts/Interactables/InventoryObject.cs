using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractableObject
{
    public string itemName;
    public override void Interaction()
    {
        FindObjectOfType<InventoryManager>().AddItems(itemName);
        Destroy(gameObject);
    }
}

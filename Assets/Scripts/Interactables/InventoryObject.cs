using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractableObject
{
    public string itemName;
    Outline outline;
    private void Start()
    {
        outline = GetComponentInChildren<Outline>();
    }
    private void Update()
    {
        outline.enabled = false;
    }
    public override void Highlight()
    {
        outline.enabled = true;
    }
    public override void Interaction()
    {
        FindObjectOfType<InventoryManager>().AddItems(itemName);
        Destroy(gameObject);
    }
}

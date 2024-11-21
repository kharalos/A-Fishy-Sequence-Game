using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : InteractableObject
{
    public enum KeyColor { yellow, red, blue, green, white, black }
    public KeyColor keyColor;
    InventoryManager inventory;
    Outline outline;

    void Start()
    {
        inventory = FindObjectOfType<InventoryManager>();
        outline = GetComponent<Outline>();
        Color color = new Color();
        if (keyColor == KeyColor.black) color = Color.black;
        if (keyColor == KeyColor.white) color = Color.white;
        if (keyColor == KeyColor.yellow) color = Color.yellow;
        if (keyColor == KeyColor.red) color = Color.red;
        if (keyColor == KeyColor.green) color = Color.green;
        if (keyColor == KeyColor.blue) color = Color.blue;
        GetComponent<MeshRenderer>().material.color = color;
        outline.enabled = false;
    }
    public override void Unhighlight()
    {
        outline.enabled = false;
    }
    public override void Highlight()
    {
        outline.enabled = true;
    }
    public override void Interaction()
    {
        if (keyColor == KeyColor.black) inventory.AddKey("black");
        if (keyColor == KeyColor.white) inventory.AddKey("white");
        if (keyColor == KeyColor.yellow) inventory.AddKey("yellow");
        if (keyColor == KeyColor.red) inventory.AddKey("red");
        if (keyColor == KeyColor.green) inventory.AddKey("green");
        if (keyColor == KeyColor.blue) { inventory.AddKey("blue");}
        Destroy(gameObject);
    }
}

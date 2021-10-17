using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadButton : InteractableObject
{
    BearManager bm;
    void Start()
    {
        bm = FindObjectOfType<BearManager>();
    }
    public override void Interaction()
    {
        bm.ButtonPressed(GetComponent<TextMeshPro>().text);
        GetComponent<AudioSource>().Play();
    }
}

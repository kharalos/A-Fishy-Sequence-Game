using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInteraction : InteractableObject
{
    public override void Interaction()
    {
        GetComponent<AudioSource>().Play();
    }
}

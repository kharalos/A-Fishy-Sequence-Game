using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aquarium : InteractableObject
{
    SubtitleManager sub;
    private void Start()
    {
        sub = FindObjectOfType<SubtitleManager>();
    }
    public override void Interaction()
    {
        sub.AddSubtitles("Glug glug",1f,false);
    }
}

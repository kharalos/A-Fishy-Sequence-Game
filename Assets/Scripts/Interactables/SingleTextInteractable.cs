using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTextInteractable : InteractableObject
{
    public string text;
    public float time = 1f;
    public bool purge;
    public override void Interaction()
    {
        FindObjectOfType<SubtitleManager>().AddSubtitles(text, time, purge);
    }
}

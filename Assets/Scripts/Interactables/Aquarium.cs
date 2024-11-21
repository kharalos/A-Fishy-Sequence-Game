using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SubtitleText
{
    public string text;
    public bool lastCycle;
    public int returnPhase;
}

public class Aquarium : InteractableObject
{
    SubtitleManager sub;
    public int phase;
    [SerializeField] private float averageTextLength = 36f;
    [SerializeField] private float averageDuration = 1f;

    public List<SubtitleText> subtitles = new List<SubtitleText>();
    private void Start()
    {
        sub = FindObjectOfType<SubtitleManager>();
    }

    public void ShowSubtitle()
    {
        var subtitle = subtitles[phase];
        sub.AddSubtitles(subtitle.text, subtitle.text.Length / averageTextLength * averageDuration, true);
        if (subtitle.lastCycle)
        {
            phase = subtitle.returnPhase;
            return;
        }
        phase++;
    }
    public override void Interaction()
    {
        ShowSubtitle();
    }
}

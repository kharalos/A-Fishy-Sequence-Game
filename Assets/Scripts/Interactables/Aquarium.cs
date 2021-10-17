using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aquarium : InteractableObject
{
    SubtitleManager sub;
    public int phase;
    private void Start()
    {
        sub = FindObjectOfType<SubtitleManager>();
    }
    public override void Interaction()
    {
        switch (phase) {
            case 0:
                sub.AddSubtitles("Glug glug...", 1f, true);
                phase++;
                break;
            case 1:
                sub.AddSubtitles("Glug glug gluglu?", 1f, true);
                phase++;
                break;
            case 2:
                sub.AddSubtitles("Alright you got me, I can talk. What a surprise.", 1f, true);
                phase++;
                break;
            case 3:
                sub.AddSubtitles("Yeah I am fine thank you for asking.", 1f, true);
                phase++;
                break;
            case 4:
                sub.AddSubtitles("Maybe you should try playing with balls.", 1f, true);
                phase++;
                break;
            case 5:
                sub.AddSubtitles("I heard some scratching sounds from the bathroom door.", 1f, true);
                phase--;
                break;
        }
    }
}

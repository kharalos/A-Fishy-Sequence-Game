using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSwitch : InteractableObject
{
    bool off;
    public override void Interaction()
    {
        if (!off)
        {
            foreach(FanHandler fan in FindObjectsOfType<FanHandler>())
            {
                fan.GetComponent<AudioSource>().volume = 0;
                fan.disabled = true;
            }
            off = true;
            GetComponent<Animator>().SetTrigger("down");
        }
        else
        {
            foreach (FanHandler fan in FindObjectsOfType<FanHandler>())
            {
                fan.GetComponent<AudioSource>().volume = 0.2f;
                fan.disabled = false;
            }
            off = false;
            GetComponent<Animator>().SetTrigger("up");
        }
        GetComponent<AudioSource>().Play();
    }
}
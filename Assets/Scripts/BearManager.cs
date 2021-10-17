using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BearManager : MonoBehaviour
{
    public GameObject bearFront;
    public TextMeshPro screenText;
    public AudioSource source;
    public bool cardInserted;
    public AudioClip[] clips;
    public string pass;

    void unlocked()
    {
        if(bearFront.GetComponent<Rigidbody>().isKinematic)bearFront.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void ButtonPressed(string key)
    {
        if (!cardInserted)
        {
            screenText.text = "Insert Card";
            source.PlayOneShot(clips[2]);
            return;
        }
        var isNumeric = int.TryParse(screenText.text, out _);
        if(!isNumeric) screenText.text = "";
        if (key == "X")
        {
            screenText.text = "";
            source.PlayOneShot(clips[0]);
            return;
        }
        if (key == "#")
        {
            if (screenText.text == pass)
            {
                source.PlayOneShot(clips[1]);
                GetComponent<Animator>().SetTrigger("key");
                return;
            }
            else
            {
                screenText.text = "#Error";
                source.PlayOneShot(clips[2]);
            }
        }
        else screenText.text += key;
    }
}

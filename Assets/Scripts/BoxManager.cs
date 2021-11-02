using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    private Animator anim;
    private int[] locksequence = { 1, 1, 1, 1, 1 };
    private bool locked = true;
    private bool closed = true;
    [SerializeField]
    private AudioSource lid, padlock;
    [SerializeField]
    private AudioClip open,close;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OpenBox()
    {
        if (locked) return;
        anim.SetTrigger("action");
        if (closed) { lid.PlayOneShot(open); closed = false; return; }
        if(!closed) { lid.PlayOneShot(close); closed = true; }
}
    public void ChangeLockSequence(int array, int value)
    {
        locksequence[array] = value;
        string sequence = String.Join(",", locksequence.Select(p => p.ToString()).ToArray());
        if (sequence == "4,3,7,7,3") { anim.SetTrigger("unlock"); locked = false; padlock.Play(); }
        Debug.Log(sequence);
    }
}

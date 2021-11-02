using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockButton : InteractableObject
{
    [SerializeField]
    private int number;
    private int octagon = 1;
    private bool rotating;
    public override void Interaction()
    {
        base.Interaction();
        if (rotating) return;
        if (octagon < 8) octagon++;
        else octagon = 1;
        rotating = true;
        GetComponent<AudioSource>().Play();
        StartCoroutine(RotateLock());
        FindObjectOfType<BoxManager>().ChangeLockSequence(number - 1, octagon);
    }
    private IEnumerator RotateLock()
    {
        for (int i = 0; i < 45; i++)
        {
            yield return new WaitForSecondsRealtime(0.01f);
            transform.Rotate(0, 0, 1f);
        }
        rotating = false;
    }
}

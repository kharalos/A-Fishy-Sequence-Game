using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : InteractableObject
{
    [SerializeField]
    private int number;
    private bool moving;
    public override void Interaction()
    {
        base.Interaction();
        if (moving) return;
        moving = true;
        FindObjectOfType<CabinetManager>().GetNumber(number, this);
    }
    public void ReturnFunc(bool dontmove)
    {
        moving = false;
    }
    public void ReturnFunc(Transform target)
    {
        StartCoroutine(Move(target));
    }

    private IEnumerator Move(Transform target)
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSecondsRealtime(0.01f);
            transform.position = Vector3.Lerp(transform.position, target.position, 0.5f);
        }
        moving = false;
    }
}

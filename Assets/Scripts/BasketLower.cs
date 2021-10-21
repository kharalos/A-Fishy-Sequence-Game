using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketLower : MonoBehaviour
{
    Basket bh;
    void Start()
    {
        bh = GetComponentInParent<Basket>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other && bh.objectIn)
        {
            bh.source.Play();
            FindObjectOfType<DollManager>().StopDoll();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other )
        {
            bh.objectIn = false;
        }
    }
}

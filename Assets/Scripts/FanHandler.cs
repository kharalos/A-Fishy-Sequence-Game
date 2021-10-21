using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanHandler : MonoBehaviour
{
    public bool disabled;
    void Update()
    {
        if(!disabled) transform.Rotate(new Vector3(0, 300 * Time.deltaTime, 0));
    }
}

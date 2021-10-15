using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanHandler : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 300 * Time.deltaTime, 0));
    }
}

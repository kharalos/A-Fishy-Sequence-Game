using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFishTrack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public LayerMask movementMask;
    void Update()
    {
        /*RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            transform.position = hit.point;
        }*/
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, 100, movementMask))
        {
            transform.position = hit.point;
        }
    }
}

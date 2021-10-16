using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteract : MonoBehaviour
{
    private GameObject raycastedObj;
    public CrosshairManager cm;
    public int rayLength = 1;

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(transform.position, fwd, out hit, rayLength))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                raycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    raycastedObj.GetComponent<InteractableObject>().Interaction();
                }
                if (Input.GetKey("e"))
                {
                    raycastedObj.GetComponent<InteractableObject>().InteractionHold();
                }
                cm.LeftBlue();
            }
        }
        else
        {
            cm.NormalizeLeft();
        }
        if (Input.GetKeyUp("e") && raycastedObj)
        {
            raycastedObj.GetComponent<InteractableObject>().InteractionStop();
        }
    }

}

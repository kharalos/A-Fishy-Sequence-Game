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

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    raycastedObj.GetComponent<InteractableObject>().Interaction();
                }
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    raycastedObj.GetComponent<InteractableObject>().InteractionHold();
                }
                raycastedObj.GetComponent<InteractableObject>().Highlight();
                cm.LeftBlue();
            }
            else cm.NormalizeLeft();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            foreach(Holdable h in FindObjectsOfType<Holdable>())
            {
                h.InteractionStop();
            }
        }
    }

}

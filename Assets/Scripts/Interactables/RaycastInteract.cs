using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteract : MonoBehaviour
{
    private InteractableObject _interactableObject;
    public CrosshairManager cm;
    public int rayLength = 1;

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        
        if(_interactableObject != null)
        {
            _interactableObject.Unhighlight();
            _interactableObject = null;
        }
        if(Physics.Raycast(transform.position, fwd, out hit, rayLength))
        {
            if (hit.collider.TryGetComponent(out _interactableObject))
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _interactableObject.Interaction();
                }
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    _interactableObject.InteractionHold();
                }
                _interactableObject.Highlight();
                cm.LeftBlue();
            }
            else
            {
                cm.NormalizeLeft();
            }
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

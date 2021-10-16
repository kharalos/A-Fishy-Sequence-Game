using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteract : MonoBehaviour
{
    private GameObject raycastedObj;

    public int rayLength = 10;
    public LayerMask layerMastInteract;

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMastInteract.value))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                raycastedObj = hit.collider.gameObject;

                if (Input.GetKeyDown("e"))
                {
                    raycastedObj.GetComponent<InteractableObject>().Interaction();
                }
            }
        }
        else
        {
            //normal
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
            FindObjectOfType<SubtitleManager>().AddTextToSubtitles("Aloha", 2f);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            FindObjectOfType<SubtitleManager>().AddTextToSubtitles("STTFU", 1f);
    }

}

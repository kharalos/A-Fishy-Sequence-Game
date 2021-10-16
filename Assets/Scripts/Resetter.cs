using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Character") FindObjectOfType<CharacterController>().GetComponent<CharacterController>().Move(Vector3.zero);
        other.transform.position = new Vector3(0,0,0);
        Debug.Log(other.gameObject.name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollTrigger : MonoBehaviour
{
    public DoorHandler handler;
    public Door door;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<DollManager>().Sing();
            handler.Interaction();
            door.keyType = Door.KeyType.black;
            FindObjectOfType<Aquarium>().phase = 7;
            Destroy(gameObject);
        }
    }
}

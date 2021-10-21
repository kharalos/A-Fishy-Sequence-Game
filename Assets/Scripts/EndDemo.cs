using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDemo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Character")
        {
            FindObjectOfType<HUDManager>().EndGame("Congratulations! You finished the demo. Thanks for playing! A game made by Kharalos");
        }
    }
}

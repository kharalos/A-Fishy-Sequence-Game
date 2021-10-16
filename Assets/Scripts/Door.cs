using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum KeyType {unlocked, yellow, red, blue, green, white, black}
    public KeyType keyType;
    public bool opened;
    public string GetKeyType()
    {
        return keyType.ToString();
    }
    public void Unlock()
    {
        keyType = KeyType.unlocked;
    }
    public void MoveDoor()
    {
        if (opened)
            opened = false;
        else opened = true;
    }
}

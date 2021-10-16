using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum KeyType {unlocked, yellow, red, blue, green, white, black}
    public KeyType keyType;
    public bool opened;
    public MeshRenderer keyholeMesh;
    private void Start()
    {
        Color color = keyholeMesh.material.color;
        if (keyType == KeyType.black) color = Color.black;
        if (keyType == KeyType.white) color = Color.white;
        if (keyType == KeyType.yellow) color = Color.yellow;
        if (keyType == KeyType.red) color = Color.red;
        if (keyType == KeyType.green) color = Color.green;
        if (keyType == KeyType.blue) color = Color.blue;
        keyholeMesh.material.color = color;
    }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<string> ownedKeys = new List<string>();

    public void AddKey(string key)
    {
        ownedKeys.Add(key);
    }
}

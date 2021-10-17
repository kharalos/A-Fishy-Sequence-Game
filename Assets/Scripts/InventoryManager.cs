using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private SoundManager sound;
    public List<string> ownedKeys = new List<string>();
    public List<string> ownedItems = new List<string>();
    private void Start()
    {
        sound = FindObjectOfType<SoundManager>();
    }
    public void AddKey(string key)
    {
        ownedKeys.Add(key);
        sound.audioSource.PlayOneShot(sound.inventoryClips[0]);
        UpdateItems();
    }
    public void AddItems(string item)
    {
        ownedItems.Add(item);
        sound.audioSource.PlayOneShot(sound.inventoryClips[2]);
        UpdateItems();
    }
    public bool CheckItem(string item)
    {
        if (ownedItems.Contains(item)) return true;
        return false;
    }
    void UpdateItems()
    {

    }
}

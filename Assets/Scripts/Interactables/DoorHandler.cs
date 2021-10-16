using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : InteractableObject
{
    public enum DoorSide {left,right}
    public DoorSide doorSide;
    private SoundManager sound;
    private AudioSource source;
    Animator anim;
    public string key;
    Door door;
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        sound = FindObjectOfType<SoundManager>();
        source = GetComponent<AudioSource>();
        door = GetComponentInParent<Door>();
        key = door.GetKeyType();
    }

    public override void Interaction()
    {
        base.Interaction();
        key = door.GetKeyType();
        if (key != "unlocked")
        {
            if (FindObjectOfType<InventoryManager>().ownedKeys.Contains(key))
            {
                door.Unlock();
                source.PlayOneShot(sound.doorClips[3]);
                return;
            }
            source.PlayOneShot(sound.doorClips[2]);
            return;
        }
        if (door.opened)
        {
            source.PlayOneShot(sound.doorClips[1]);
            door.MoveDoor();
        }
        else
        {
            source.PlayOneShot(sound.doorClips[0]);
            door.MoveDoor();
        }
        if (doorSide == DoorSide.left)
        {

            anim.SetTrigger("Left");
        }
        if (doorSide == DoorSide.right)
        {
            anim.SetTrigger("Right");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollManager : MonoBehaviour
{
    public AudioClip[] clips;
    AudioSource source;
    Animator anim;
    Vector3 targetPos;
    void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponentInChildren<AudioSource>();
    }
    public void Sing()
    {
        source.PlayOneShot(clips[0]);
        StartCoroutine(Action());
    }
    IEnumerator Action()
    {
        yield return new WaitForSeconds(clips[0].length);
        anim.SetTrigger("action");
    }
    void TurnHead()
    {
        source.PlayOneShot(clips[1]);

    }
    void Analyze()
    {
        source.PlayOneShot(clips[2]);
        targetPos = GameObject.FindGameObjectWithTag("HoldingTarget").transform.position;
    }
    void ReturnHead()
    {
        source.PlayOneShot(clips[1]);
        if (targetPos == GameObject.FindGameObjectWithTag("HoldingTarget").transform.position)
        {
            Success();
        }
        else Fail();
    }
    void Success()
    {
        StartCoroutine(SingInterval());
    }
    IEnumerator SingInterval()
    {
        yield return new WaitForSeconds(Random.Range(2f,10f));
        Sing();
    }
    void Fail()
    {
        source.PlayOneShot(clips[3]);
        FindObjectOfType<HUDManager>().EndGame("You have been shot!");
    }
    public Door door;
    bool stopped;
    public void StopDoll()
    {
        if (!stopped)
        {
            source.Stop();
            anim.speed = 0f;
            door.keyType = Door.KeyType.yellow;
            StopAllCoroutines();
            stopped = true;
        }
    }
}

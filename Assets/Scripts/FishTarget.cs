using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishTarget : MonoBehaviour
{
    private float locationX, locationY, locationZ;
    private Vector3 targetPos;
    void Start()
    {
        locationX = .19f;
        locationY = .15f;
        locationZ = .35f;
        StartCoroutine(RandomLocation());
    }
    IEnumerator RandomLocation()
    {
        targetPos = new Vector3(Random.Range(-locationX, locationX), Random.Range(-locationY, locationY), Random.Range(-locationZ, locationZ));
        yield return new WaitForSeconds(8f);
        StartCoroutine(RandomLocation());
    }
    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, .5f * Time.deltaTime);
    }
}

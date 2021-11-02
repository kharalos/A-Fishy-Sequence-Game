using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SeagullManager : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(FindObjectOfType<Controller>().transform.position);
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("Vertical", speedPercent, .1f, Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //[SerializeField] private Transform enterance;
    [SerializeField] private Transform exit;
    [SerializeField] private NavMeshAgent thisAgent;

    [SerializeField] private Animator anim;

    void Start()
    {
        exit = GameObject.Find("Exit").transform;
        thisAgent = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>();
        thisAgent.SetDestination(exit.position);

    }

    void Update()
    {
        //Rigidbody rb = GetComponent<Rigidbody>();
        //Vector3 v3Velocity = rb.velocity;
        //if (thisAgent.isStopped)
        //{
        //    anim.SetFloat("Velocity", 0);
        //}
        //else
        //{
        //    anim.SetFloat("Velocity", 01);

        //}
        Debug.Log(thisAgent.isStopped);
        anim.SetBool("isMoving", !thisAgent.isStopped);
        
    }
}

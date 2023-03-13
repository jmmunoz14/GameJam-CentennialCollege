using System;
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

    [SerializeField] private int hp;
    [SerializeField] private float speed;

    [SerializeField] private bool armor = false;
    [SerializeField] private bool explode = false;
    [SerializeField] private bool stealth = false;

    public static event Action OnBugDeath;
    void Start()
    {
        exit = GameObject.Find("Exit").transform;
        thisAgent = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>();
        thisAgent.SetDestination(exit.position);

    }

    void Update()
    {
        anim.SetBool("isMoving", !thisAgent.isStopped);
    }

    void Death()
    {
        anim.SetTrigger("Die");
        OnBugDeath?.Invoke();
    }


}

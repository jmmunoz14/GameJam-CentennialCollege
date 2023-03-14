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

    [SerializeField] public int hp = 100;
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

    public void TakeDamage(int damage)
    {
        if (!armor)
        {
            hp -= damage;
        }else if(hp <= 0)
        {
            Death();
        }
        Debug.Log(this.name + " HP: " + hp);
    }


}

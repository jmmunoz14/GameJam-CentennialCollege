using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemyHealth enemyHealth;

    //[SerializeField] private Transform enterance;
    [SerializeField] private Transform exit;
    [SerializeField] private NavMeshAgent thisAgent;

    [SerializeField] private Animator anim;

    [SerializeField] public int hp = 100;
    [SerializeField] private float speed;

    [SerializeField] public bool isArmored = false;
    [SerializeField] public bool isExplosive = false;
    [SerializeField] public bool isSteathly = false;

    public static event Action OnBugDeath;
    void Start()
    {
        exit = GameObject.Find("Exit").transform;
        thisAgent = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>();
        thisAgent.SetDestination(exit.position);
        enemyHealth = GetComponent<EnemyHealth>();

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
        if (!isArmored)
        {
            enemyHealth.currentHealth -= damage;
        }

        if (enemyHealth.currentHealth <= 0)
        {
            Death();
        }

        //Debug.Log(this.name + " HP: " + enemyHealth.currentHealth);
    }




}

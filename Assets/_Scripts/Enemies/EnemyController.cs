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

     public bool isArmored = false;
     public bool isExplosive = false;
     public bool isSteathly = false;

    public static event Action OnBugDeath;
    void Start()
    {
        exit = GameObject.Find("Exit").transform;
        thisAgent = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>();
        thisAgent.SetDestination(exit.position);
        enemyHealth = GetComponent<EnemyHealth>();
        GameState.Instance.OnGameLose += Stop;

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
           if (!isSteathly)
            {
                enemyHealth.currentHealth -= damage;

            }
        }


        if (enemyHealth.currentHealth <= 0)
        {
            Death();
        }

        //Debug.Log(this.name + " HP: " + enemyHealth.currentHealth);
    }

    private void OnDestroy()
    {
        GameState.Instance.OnGameLose -= Stop;

    }

    private void Stop()
    {
        thisAgent.isStopped = true;
    }




}

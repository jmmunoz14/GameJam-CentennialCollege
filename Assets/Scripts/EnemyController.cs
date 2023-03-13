using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //[SerializeField] private Transform enterance;
    [SerializeField] private Transform exit;
    [SerializeField] private NavMeshAgent thisAgent;

    void Start()
    {
        exit = GameObject.Find("Exit").transform;
        thisAgent.SetDestination(exit.position);
    }

    void Update()
    {
        
    }
}

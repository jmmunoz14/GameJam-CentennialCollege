using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDetection : MonoBehaviour
{

    private Transform _currentTarget;

    [SerializeField] private GameObject areaDamager;
    [SerializeField] private ParticleSystem particleSys;
    public Transform CurrentTarget
    {
        get 
        {
            return _currentTarget;
        }
        private set
        {
            _currentTarget = value;
            OnTargetUpdate?.Invoke(_currentTarget);
        }
    }

    public Action<Transform> OnTargetUpdate;


    [SerializeField] private float range;
    [SerializeField] private float _searchIntervalInSeconds;
    private bool _isSearching;


    private void Start()
    {
        StartSearching();
    }    

    private void Update()
    {
        if (_currentTarget == null) return;

        // Check to see if the target went out of range
        if (Vector3.Distance(CurrentTarget.position, transform.position) > range)
        {
            CurrentTarget = null;
            particleSys.Stop();
            StartSearching();
        }
    }

    public void GetNextTarget()
    {

        // > loop through all enemies on screen
        foreach (EnemyController bug in BugLedger.Instance.Bugs)
        {
            if (bug.GetComponent<EnemyController>().isSteathly)
            {
                continue;
            }
            if (Vector3.Distance(bug.transform.position, transform.position) <= range)
            {
                CurrentTarget = bug.transform;
                particleSys.Play();
                areaDamager.SetActive(true);
                StopSearching();
                return;
            }
        }
    }

    private void StartSearching()
    {
        _isSearching = true;
        StartCoroutine(SearchForTargets());
    }

    private void StopSearching()
    {
        _isSearching = false;
    }

    IEnumerator SearchForTargets()
    {
        while (_isSearching)
        {
            GetNextTarget();
            yield return new WaitForSeconds(_searchIntervalInSeconds);
        }
    }
   

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

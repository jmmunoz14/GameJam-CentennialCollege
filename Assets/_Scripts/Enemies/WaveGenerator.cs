using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveGenerator : MonoBehaviour
{
    [SerializeField] private Transform enterance;
    [SerializeField] private int nextWaveTimeInSec = 5;

    [SerializeField] GameObject[] bugPrefabs;

    [SerializeField] private bool isGeneratingWave = true;

    [SerializeField] private BugType bugType = BugType.SimpleBug;

    public enum BugType
    {
        SimpleBug,
        ArmoredBug,
        ExplosiveBug,
        StealthBug

    }
    void Start()
    {
        isGeneratingWave = true;
        StartCoroutine(GenerateWaves());

    }    

    IEnumerator GenerateWaves()
    {
        EnemyController newEnemy;

        while (isGeneratingWave)
        {
            newEnemy = null;
            switch (bugType)
            {
                case BugType.SimpleBug:
                    newEnemy = Instantiate(bugPrefabs[0], enterance.position, Quaternion.identity).GetComponent<EnemyController>();
                    break;
                case BugType.ArmoredBug:
                    newEnemy = Instantiate(bugPrefabs[1], enterance.position, Quaternion.identity).GetComponent<EnemyController>();
                    break;
                case BugType.ExplosiveBug:
                    newEnemy = Instantiate(bugPrefabs[2], enterance.position, Quaternion.identity).GetComponent<EnemyController>();
                    break;
                case BugType.StealthBug:
                    newEnemy = Instantiate(bugPrefabs[3], enterance.position, Quaternion.identity).GetComponent<EnemyController>();
                    break;
                default:
                    break;                
            }


            if (newEnemy != null)
            {
                BugLedger.Instance.Bugs.Add(newEnemy);
                Debug.Log("BugCount" + BugLedger.Instance.Bugs.Count);
            }

            yield return new WaitForSeconds(nextWaveTimeInSec);

        }
    }
}

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

    void Update()
    {

    }

    IEnumerator GenerateWaves()
    {
        while (isGeneratingWave)
        {
            switch (bugType)
            {
                case BugType.SimpleBug:
                    Instantiate(bugPrefabs[0], enterance.position, Quaternion.identity);
                    break;
                case BugType.ArmoredBug:
                    Instantiate(bugPrefabs[1], enterance.position, Quaternion.identity);
                    break;
                case BugType.ExplosiveBug:
                    Instantiate(bugPrefabs[2], enterance.position, Quaternion.identity);
                    break;
                case BugType.StealthBug:
                    Instantiate(bugPrefabs[3], enterance.position, Quaternion.identity);
                    break;
                default:
                    break;
            }

            yield return new WaitForSeconds(nextWaveTimeInSec);

        }
    }
}

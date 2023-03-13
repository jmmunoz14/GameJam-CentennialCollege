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

            Instantiate(bugPrefabs[0], enterance.position, Quaternion.identity);
            yield return new WaitForSeconds(nextWaveTimeInSec);

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveGenerator : MonoBehaviour
{
    [SerializeField] private Transform entrance;
    [SerializeField] private List<Wave> waves = new List<Wave>();

    private int _waveIndex = 0;
    private int _waveGroupIndex = 0;
    private int _enemyIndex = 0;

    private bool isGeneratingWave = true;
    private bool isFirstWave = true;

    private WaveGroup _currentWaveGroup;

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
        StartCoroutine(SpawnWaves());
    }

    void GetNextWaveGroup()
    {
        if (isFirstWave)
        {
            Debug.Log("First Wave");
            isFirstWave = false;
            GetWaveGroup(_waveIndex, _waveGroupIndex);
            return;
        }
        // Check if Wave Group is complete
        if (_enemyIndex >= _currentWaveGroup.EnemyCount)
        {
            _waveGroupIndex++;
            _enemyIndex = 0;
        }

        // Check if all groups in wave are done.
        if (_waveGroupIndex >= waves[_waveIndex].WaveGroups.Count)
        {
            _waveIndex++;
            _waveGroupIndex = 0;
        }

        // > Check if All Waves are complete
        if (_waveIndex >= waves.Count)
        {
            isGeneratingWave = false;
            return;
        }

       GetWaveGroup(_waveIndex, _waveGroupIndex);
    }

    void GetWaveGroup(int waveIndex, int waveGroupIndex)
    {
        _currentWaveGroup = waves[_waveIndex].WaveGroups[_waveGroupIndex];
    }

    IEnumerator SpawnWaves()
    {
        while (isGeneratingWave)
        {
            GetNextWaveGroup();

            if (_currentWaveGroup.EnemyPrefab != null)
            {
                EnemyController newEnemy;
                newEnemy = Instantiate(_currentWaveGroup.EnemyPrefab, entrance.position, Quaternion.identity).GetComponent<EnemyController>();
                BugLedger.Instance.Bugs.Add(newEnemy);
            }

            _enemyIndex++;
            yield return new WaitForSeconds(_currentWaveGroup.spawnIntervalSeconds);
        }        
    }
}

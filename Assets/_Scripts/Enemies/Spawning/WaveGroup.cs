using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveGroup", menuName = "ScriptableObjects/WaveGroup", order = 1)]
public class WaveGroup : ScriptableObject
{
    public GameObject EnemyPrefab;
    public int EnemyCount;
    public float spawnIntervalSeconds;
}

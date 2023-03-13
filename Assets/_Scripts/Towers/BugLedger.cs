using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugLedger : MonoBehaviour
{
    public static BugLedger Instance
    {
        get
        {
            return _instance;
        }
    }

    private static BugLedger _instance;

    [SerializeField] public List<EnemyController> Bugs { get; private set; } = new List<EnemyController>();
    

    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
        }
        if (Instance != this)
        {
            Destroy(this);
        }
    }
}

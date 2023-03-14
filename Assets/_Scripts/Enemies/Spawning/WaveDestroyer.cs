using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameState.Instance.DamagePlayer(1);
            BugLedger.Instance.Bugs.Remove(other.GetComponent<EnemyController>());
            Destroy(other.gameObject);
        }
    }
}

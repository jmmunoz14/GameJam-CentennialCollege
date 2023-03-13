using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FumigatorDamager : MonoBehaviour
{
    [SerializeField] int damageRate = 40;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("YOYOOOOO");
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().TakeDamage(damageRate);
        }
    }

}

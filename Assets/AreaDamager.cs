using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamager : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Debug.Log("collision");
            StartCoroutine(DamageBug(other.gameObject));
        }
    }

    IEnumerator DamageBug(GameObject bug)
    {
        while (bug != null)
        {
            bug.GetComponent<EnemyController>().TakeDamage(5);
            yield return new WaitForSeconds(1.0f);
        }
    }
}

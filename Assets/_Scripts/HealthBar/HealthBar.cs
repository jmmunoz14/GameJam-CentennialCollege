using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public float currentHealth = 100;
    public float maxHealth = 100;

    void LateUpdate()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        healthSlider.transform.position = pos;
    }

    void Update()
    {
        healthSlider.value = currentHealth / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // Do something when the game object dies
        }
    }
}

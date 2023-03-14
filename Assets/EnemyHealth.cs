using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider healthSlider;
    public GameObject healthBarUI;
    public float currentHealth = 100;
    public float maxHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.value=CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = CalculateHealth();
        if (currentHealth < maxHealth) {
            healthBarUI.SetActive(true);
        }

        if (currentHealth <= 0) {
            Destroy(gameObject);
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

    }

    float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }
}

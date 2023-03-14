using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text healthValue;
    // Start is called before the first frame update
    void Start()
    {
        GameState.Instance.OnHealthChanged += UpdateHealth;
        healthValue.text = 1.ToString();
    }

    private void UpdateHealth(int health)
    {
        Debug.Log("Updating Health");
        healthValue.text = health.ToString();
    }

    private void OnDestroy()
    {
        GameState.Instance.OnHealthChanged -= UpdateHealth;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance
    {
        get
        {
            return _instance;
        }
    }

    private static GameState _instance;


    private int _playerHealth;
    public int PlayerHealth { 
        get
        {
            return _playerHealth;
        }
        private set 
        {
            _playerHealth = (int)Mathf.Max(0f, value);
            OnHealthChanged?.Invoke(_playerHealth);

            if(_playerHealth >= 0)
            {
                OnGameLose?.Invoke();
            }
        }
    }   

    [SerializeField] private int _startingHealth;


    public Action<int> OnRemainingTimeChanged;
    public Action<int> OnHealthChanged;
    public Action OnGameLose;
    public Action OnGameWin;

    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
            PlayerHealth = _playerHealth;
            OnHealthChanged?.Invoke(PlayerHealth);
        }
        if (Instance != this)
        {
            Destroy(this);
        }
    }   

    public void DamagePlayer(int amount)
    {
        PlayerHealth = PlayerHealth - amount;
    }
}

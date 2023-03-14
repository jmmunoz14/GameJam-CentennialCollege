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
    private float _remainingTime;
    private int RemainingTime
    {
        get
        {
            return (int)_remainingTime;
        }
        set
        {
            if((int)value !=  _remainingTime)
            {
                _remainingTime = value;
                OnRemainingTimeChanged?.Invoke((int)_remainingTime);
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
        }
        if (Instance != this)
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if(_remainingTime > 0f)
        {
            _remainingTime -= Time.deltaTime;
        }
    }

    public void DamagePlayer(int amount)
    {
        PlayerHealth = PlayerHealth - amount;
    }
}

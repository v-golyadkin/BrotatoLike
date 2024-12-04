using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinWallet : MonoBehaviour
{
    public static CoinWallet Instance;

    public int Coins => _coinCount;

    public event Action<int> OnCoinsChanged;

    private int _coinCount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _coinCount = 0;
    }

    public void AddCoins(int amount)
    {
        _coinCount += amount;
        OnCoinsChanged?.Invoke(_coinCount);
    }
}

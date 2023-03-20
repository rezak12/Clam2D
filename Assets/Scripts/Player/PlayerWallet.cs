using System;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private int _coins;
    public event Action<int> CoinAdded;

    private void Awake()
    {
        WalletInitialize();
    }

    private void OnDisable()
    {
        SaveCoins();
    }

    private void OnApplicationPause(bool pause)
    {
        SaveCoins();
    }

    public void AddCoin()
    {
        _coins++;
        CoinAdded?.Invoke(_coins);
    }
    private void WalletInitialize()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            _coins = PlayerPrefs.GetInt("Coins");
        }
        else
        {
            _coins = 0;
        }
        CoinAdded?.Invoke(_coins);
    }
    private void SaveCoins()
    {
        PlayerPrefs.SetInt("Coins", _coins);
        PlayerPrefs.Save();
    }
}

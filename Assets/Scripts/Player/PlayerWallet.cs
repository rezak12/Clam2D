using System;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public int Coins { get; private set; }
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
        Coins++;
        CoinAdded?.Invoke(Coins);
    }
    private void WalletInitialize()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            Coins = PlayerPrefs.GetInt("Coins");
        }
        else
        {
            Coins = 0;
        }
        CoinAdded?.Invoke(Coins);
    }
    private void SaveCoins()
    {
        PlayerPrefs.SetInt("Coins", Coins);
        PlayerPrefs.Save();
    }
}

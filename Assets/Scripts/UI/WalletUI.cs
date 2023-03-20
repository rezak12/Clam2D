using UnityEngine;
using TMPro;

public class WalletUI : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private TMP_Text _counter;

    private void OnEnable()
    {
        _playerWallet.CoinAdded += SetValue;
    }
    private void OnDisable()
    {
        _playerWallet.CoinAdded -= SetValue;
    }

    private void SetValue(int count)
    {
        _counter.text = count.ToString();
    }
}

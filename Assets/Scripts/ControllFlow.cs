using UnityEngine;

public class ControllFlow : MonoBehaviour
{
    [Header("Game controll")]
    [SerializeField] private PauseSwitcher _pauseSwitcher;
    [SerializeField] private PlayerStats _playerStats;

    [Header("Advertisements")]
    [SerializeField] private StartBonusAd _healthBonus;
    [SerializeField] private StartBonusAd _liveTimeBonus;
    [SerializeField] private StartBonusAd _shieldBonus;
    [Header("Reward")]
    [SerializeField] private float _timeForShieldInseconds = 20;

    private void Awake()
    {
        _healthBonus.AdShowCompleted += _playerStats.ChangeStartMaxHealth;
        _liveTimeBonus.AdShowCompleted += _playerStats.ChangeStartTimeToLive;
        _shieldBonus.AdShowCompleted += StartShieldBonus;
    }

    private void Start()
    {
        _pauseSwitcher.SetPause();
    }

    private void OnDestroy()
    {
        _healthBonus.AdShowCompleted -= _playerStats.ChangeStartMaxHealth;
        _liveTimeBonus.AdShowCompleted -= _playerStats.ChangeStartTimeToLive;
        _shieldBonus.AdShowCompleted -= StartShieldBonus;
    }

    private void StartShieldBonus()
    {
        _playerStats.EquipShield(_timeForShieldInseconds);
    }
}

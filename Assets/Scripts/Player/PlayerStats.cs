using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int Health { get; private set; }
    [SerializeField] private int _maxHealth = 3;

    public float CurrentTimeLeftInSeconds { get; private set; }
    [SerializeField] private float _maxTimeLeftInSeconds = 30;

    public float TimeLeftForShield { get; private set; } = 0;
    [SerializeField] private GameObject _shieldObject;

    public event Action DamageTaked;
    public event Action<int> HealthChanged;
    public event Action GameOvered;
    public event Action<float> LiveTimeChanged;
    public event Action<float> ShieldTimeChanged;

    private void Awake()
    {
        Health = _maxHealth;
        CurrentTimeLeftInSeconds = _maxTimeLeftInSeconds;
    }

    private void Update()
    {
        CheckTimeForLiving();
        CheckTimeForShield();
    }

    public void AddTimeToLive(float timeInSeconds)
    {
        if (timeInSeconds < 0 || timeInSeconds > 60)
        {
            Debug.LogWarning("Not valid time gived to " + gameObject.name);
            return;
        }

        if (timeInSeconds + CurrentTimeLeftInSeconds > _maxTimeLeftInSeconds)
        {
            _maxTimeLeftInSeconds = timeInSeconds;
        }

        CurrentTimeLeftInSeconds += timeInSeconds;
    }

    /// <summary>
    /// Add 1/2 of max time to live current time left
    /// </summary>
    public void ChangeStartTimeToLive()
    {
        CurrentTimeLeftInSeconds += _maxTimeLeftInSeconds / 2;
    }

    public void AddLife()
    {
        if (Health + 1 > _maxHealth)
        {
            return;
        }
        Health++;
        HealthChanged?.Invoke(Health);
    }

    public void ChangeStartMaxHealth()
    {
        _maxHealth = 4;
        Health = _maxHealth;
        HealthChanged?.Invoke(Health);
    }

    public void EquipShield(float timeForShieldInSeconds)
    {
        if (timeForShieldInSeconds <= 0 || timeForShieldInSeconds > 60)
        {
            Debug.LogWarning("Not valid time gived to " + gameObject.name);
            return;
        }
        _shieldObject.gameObject.SetActive(true);
        TimeLeftForShield += timeForShieldInSeconds;
        ShieldTimeChanged?.Invoke(TimeLeftForShield);
    }

    public void TakeDamage()
    {
        if (TimeLeftForShield > 0)
        {
            UnequipShield();
            return;
        }

        Health--;
        if (Health <= 0)
        {
            GameOver();
        }
        else
        {
            DamageTaked?.Invoke();
        }
        HealthChanged?.Invoke(Health);
    }

    public void Respawn()
    {
        gameObject.SetActive(true);
        if(CurrentTimeLeftInSeconds < 10)
        {
            AddTimeToLive(30);
        }
        if(Health < 1)
        {
            AddLife();
        }
        if(TimeLeftForShield < 5)
        {
            EquipShield(5);
        }
    }

    private void UnequipShield()
    {
        TimeLeftForShield = 0;
        _shieldObject.gameObject.SetActive(false);
        ShieldTimeChanged?.Invoke(TimeLeftForShield);
    }

    private void GameOver()
    {
        gameObject.SetActive(false);
        GameOvered?.Invoke();
        Debug.Log("Game Over");
    }

    private void CheckTimeForShield()
    {
        if (TimeLeftForShield > 0)
        {
            TimeLeftForShield -= Time.deltaTime;
            if (TimeLeftForShield <= 0)
            {
                UnequipShield();
            }
            ShieldTimeChanged?.Invoke(TimeLeftForShield);
        }
    }

    private void CheckTimeForLiving()
    {
        CurrentTimeLeftInSeconds -= Time.deltaTime;
        LiveTimeChanged?.Invoke(CurrentTimeLeftInSeconds);
        if (CurrentTimeLeftInSeconds <= 0)
        {
            GameOver();
        }
    }
}

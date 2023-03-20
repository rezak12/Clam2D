using UnityEngine;

public class ShieldBonus : InteractableObject
{
    [SerializeField] private float _timeForShieldInSeconds = 5f;

    public override void Interact(PlayerStats playerStats)
    {
        playerStats.EquipShield(_timeForShieldInSeconds);
    }
}

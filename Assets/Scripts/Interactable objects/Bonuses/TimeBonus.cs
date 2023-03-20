using UnityEngine;

public class TimeBonus : InteractableObject
{
    [SerializeField] private float _timeToAddInSeconds = 5f;

    public override void Interact(PlayerStats playerStats)
    {
        playerStats.AddTimeToLive(_timeToAddInSeconds);
    }
}

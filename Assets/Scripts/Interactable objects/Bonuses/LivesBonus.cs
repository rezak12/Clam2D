using UnityEngine;

public class LivesBonus : InteractableObject
{
    [SerializeField, Tooltip("Will bonus increase health or decrease?")] private bool _increaseHealth = true;

    public override void Interact(PlayerStats playerStats)
    {
        if (_increaseHealth)
        {
            playerStats.AddLife();
        }
        else
        {
            playerStats.TakeDamage();
        }
    }
}

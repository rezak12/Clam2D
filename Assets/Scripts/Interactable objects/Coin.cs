using UnityEngine;

public class Coin : InteractableObject
{
    public override void Interact(PlayerStats playerStats)
    {
        playerStats.GetComponent<PlayerWallet>().AddCoin();
    }
}

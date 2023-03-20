using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStats playerStats = collision.GetComponent<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.TakeDamage();
            playerStats.GetComponent<PlayerMovement>().OnDamageTaken();
            return;
        }

        Destroy(collision.gameObject);
    }
}

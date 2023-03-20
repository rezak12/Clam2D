using UnityEngine;

public abstract class InteractableObject : MonoBehaviour, ISpawnable, IInteractable
{
    [SerializeField, Range(0, 1)] private float _spawnChanse = 0.5f;
    public float ChanseToSpawn => _spawnChanse;

    public virtual void Interact(PlayerStats playerStats)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStats playerStats = collision.GetComponent<PlayerStats>();
        if (playerStats != null)
        {
            Interact(playerStats);
            Destroy(gameObject);
        }
    }
}

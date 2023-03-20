using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : InteractableObject
{
    [SerializeField] private float _xMoveForce = 5f;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(-_xMoveForce, 0);
    }
    public override void Interact(PlayerStats playerStats)
    {
        playerStats.TakeDamage();
    }
}

using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _xJumpForce = 0.1f;
    [SerializeField] private float _yJumpForce = 0.1f;
    [SerializeField] private float _increaseForceValue = 0.0002f;

    [SerializeField] private Camera _camera;

    private PlayerInput _input;
    private Rigidbody2D _rb;

    private void OnEnable()
    {
        _input = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody2D>();
        _input.Clicked += Jump;
    }

    private void OnDisable()
    {
        _input.Clicked -= Jump;
    }

    void FixedUpdate()
    {
        _xJumpForce += _increaseForceValue;
    }

    public void Jump()
    {
        Vector2 force = new Vector2(Vector3.right.x * _xJumpForce, _yJumpForce);
        _rb.velocity = force;
    }

    public void OnDamageTaken()
    {
        _rb.position = _camera.transform.position;
        _rb.velocity = new Vector2(_xJumpForce * 2, 0);
    }
}

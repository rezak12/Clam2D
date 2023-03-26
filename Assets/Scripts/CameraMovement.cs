using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _lerpSpeed = 1.2f;
    [SerializeField] private float _increaseValue = 0.0002f;

    void FixedUpdate()
    {
        _lerpSpeed += _increaseValue;
        Vector3 newPosition = new Vector3(transform.position.x + _lerpSpeed, transform.position.y, -1);
        newPosition = Vector3.Lerp(transform.position, newPosition, _lerpSpeed * Time.fixedDeltaTime);
        transform.position = newPosition;
    }
}

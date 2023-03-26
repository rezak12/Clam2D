using System;
using System.Collections;
using UnityEngine;

public class WheelOfFortune : MonoBehaviour
{
    [SerializeField] private float _timeForRotatingInSeconds = 10f;
    [SerializeField] private float _startSpeed = 800f;
    private float _currentSpeed;
    private float _timeLeft;

    [SerializeField] private GameObject _wheel;
    [SerializeField] private WheelOfFortunePointer _pointer;

    public event Action<string> OnWheelStop;

    private void Start()
    {
        _timeLeft = _timeForRotatingInSeconds;
        _currentSpeed = _startSpeed;
    }

    public void StartRotating()
    {
        StartCoroutine(IStartRotating());
    }

    private IEnumerator IStartRotating()
    {
        while (_timeLeft > 0)
        {
            if (_timeLeft >= _timeForRotatingInSeconds / 2)
            {
                _currentSpeed = Mathf.Lerp(_currentSpeed, _startSpeed / 2, Time.deltaTime);
            }
            else if ((_timeLeft >= _timeForRotatingInSeconds / 4 && _timeLeft <= _timeForRotatingInSeconds / 2))
            {
                _currentSpeed = Mathf.Lerp(_currentSpeed, _startSpeed / 4, Time.deltaTime);
            }
            else if ((_timeLeft >= 0 && _timeLeft <= _timeForRotatingInSeconds / 2))
            {
                _currentSpeed = Mathf.Lerp(_currentSpeed, 0, Time.deltaTime);
            }

            _wheel.transform.Rotate(Vector3.forward, _currentSpeed * Time.deltaTime);
            yield return null;
            _timeLeft -= Time.deltaTime;
        }

        var prizeID = _pointer.CurrentPrizeID;
        OnWheelStop?.Invoke(prizeID);
        Debug.Log($"Prize ID - {prizeID}");
        _timeLeft = _timeForRotatingInSeconds;
        _currentSpeed = _startSpeed;
    }
}

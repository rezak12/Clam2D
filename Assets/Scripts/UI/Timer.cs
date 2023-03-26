using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _timeInSeconds;
    
    public event Action TimerOn;
    public event Action TimerOff;

    private float _timeLeft;

    private void OnEnable()
    {
        _slider = GetComponent<Slider>();
        _timeLeft = Time.time + _timeInSeconds;
        _slider.maxValue = _timeInSeconds;
        TimerOn?.Invoke();
    }

    private void Update()
    {
        if(_timeLeft > Time.time)
        {
            _slider.value = _timeLeft - Time.time;
        }
        if(_timeLeft <= Time.time)
        {
            TimerOff?.Invoke();
        }
    }
}

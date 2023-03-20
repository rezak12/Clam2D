public class TimeLeftCounter : PlayerStatCounterUI
{
    private void Start()
    {
        _bar.SetValue(_stats.CurrentTimeLeftInSeconds);
    }
    private void OnEnable()
    {
        _stats.LiveTimeChanged += _bar.SetValue;
    }
    private void OnDisable()
    {
        _stats.LiveTimeChanged -= _bar.SetValue;
    }
}

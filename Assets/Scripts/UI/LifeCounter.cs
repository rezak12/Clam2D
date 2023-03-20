public class LifeCounter : PlayerStatCounterUI
{
    private void Start()
    {
        _bar.SetValue(_stats.Health);
    }
    private void OnEnable()
    {
        _stats.HealthChanged += (_bar.SetValue);
    }
    private void OnDisable()
    {
        _stats.LiveTimeChanged -= (_bar.SetValue);
    }
}

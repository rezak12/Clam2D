public class ShieldTimeLeftCounter : PlayerStatCounterUI
{
    private void Start()
    {
        _bar.SetValue(_stats.TimeLeftForShield);
    }
    private void OnEnable()
    {
        _stats.ShieldTimeChanged += (_bar.SetValue);
    }
    private void OnDisable()
    {
        _stats.ShieldTimeChanged -= (_bar.SetValue);
    }
}

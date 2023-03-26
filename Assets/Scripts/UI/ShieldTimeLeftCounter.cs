public class ShieldTimeLeftCounter : PlayerStatCounterUI
{
    private void OnEnable()
    {
        _stats.ShieldTimeChanged += _bar.SetValue;
        _bar.SetValue(_stats.TimeLeftForShield);
    }
    private void OnDestroy()
    {
        _stats.ShieldTimeChanged -= _bar.SetValue;
    }
}

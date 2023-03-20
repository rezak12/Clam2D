using UnityEngine;

public abstract class Bar : MonoBehaviour
{
    public virtual void SetValue(float value) { }
    public virtual void SetValue(int value) { }
    protected virtual void SetMaxValue(float value) { }
    protected virtual void SetMaxValue(int value) { }
}

using UnityEngine;
using UnityEngine.UI;

public class FloatBar : Bar
{
    [SerializeField] private Slider barSlider;

    public override void SetValue(float value)
    {
        if (value > barSlider.maxValue)
        {
            SetMaxValue(value);
        }
        barSlider.value = value;

        if (barSlider.value <= 0)
        {
            gameObject.SetActive(false);
        }
        else if (!gameObject.activeSelf && barSlider.value > 0)
        {
            gameObject.SetActive(true);
        }
    }

    protected override void SetMaxValue(float value)
    {
        barSlider.maxValue = value;
    }
}

using UnityEngine.UI;

public class FloatBar : Bar
{
    private Slider barSlider;

    private void Start()
    {
        barSlider = GetComponent<Slider>();
    }
    public override void SetValue(float value)
    {
        if (value > barSlider.maxValue)
        {
            SetMaxValue(value);
        }
        barSlider.value = value;

        if(barSlider.value <= 0)
        {
            gameObject.SetActive(false);
        }
        else if(!barSlider.IsActive() && barSlider.value > 0)
        {
            gameObject.SetActive(true);
        }
    }

    protected override void SetMaxValue(float value)
    {
        barSlider.maxValue = value;
    }
}

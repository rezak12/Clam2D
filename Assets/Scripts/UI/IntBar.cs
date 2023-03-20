using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntBar : Bar
{
    [SerializeField] private List<Image> points;
    public override void SetValue(int value)
    {
        points.ForEach((point) => point.enabled = false);
        for (int i = 0; i < value; i++)
        {
            points[i].enabled = true;
        }
    }

    protected override void SetMaxValue(int value)
    {
        
    }
}

using UnityEngine;
using UnityEngine.UI;

public class WheelOfFortuneSection : MonoBehaviour
{
    [SerializeField] private Image _iconField;
    [SerializeField] private WheelOfFortuneSectionData _sectionData;
    public string PrizeId => _sectionData.PrizeID;

    private void Start()
    {
        _iconField.sprite = _sectionData.Icon;
    }
}

using UnityEngine;

[CreateAssetMenu(menuName = "Wheel of Fortune/Prize Data")]
public class WheelOfFortuneSectionData : ScriptableObject
{
    [SerializeField] private string _prizeID;
    [SerializeField] private Sprite _icon;
    public string PrizeID => _prizeID;
    public Sprite Icon => _icon;
}

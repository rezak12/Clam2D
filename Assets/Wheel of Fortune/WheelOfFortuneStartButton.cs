using UnityEngine;
using UnityEngine.UI;

public class WheelOfFortuneStartButton : MonoBehaviour
{
    [SerializeField] private int costOfSpin = 10;
    [SerializeField] private WheelOfFortune _wheel;
    [SerializeField] private GameObject _notEnoughtMoneyPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Spin);
    }

    private void OnDestroy()
    {
        GetComponent<Button>().onClick.RemoveListener(Spin);
    }

    public void Spin()
    {
        int coins = PlayerPrefs.GetInt("Coins");
        if(coins < costOfSpin)
        {
            _notEnoughtMoneyPanel.SetActive(true);
            return;
        }
        coins -= costOfSpin;
        PlayerPrefs.SetInt("Coins", coins);
        _wheel.StartRotating();
    }
}

using UnityEngine;

public class WheelOfFortunePointer : MonoBehaviour
{
    public string CurrentPrizeID { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var section = collision.GetComponent<WheelOfFortuneSection>();
        if (section != null)
        {
            CurrentPrizeID = section.PrizeId;
        }
    }
}

using UnityEngine;

public class PauseSwitcher : MonoBehaviour
{
    public void SetPause()
    {
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
    }
}

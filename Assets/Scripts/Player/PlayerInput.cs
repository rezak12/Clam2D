using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private bool _IsPlaying = false;

    public event Action Clicked;
    public event Action FirstClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_IsPlaying)
            {
                FirstClicked?.Invoke();
                _IsPlaying = true;
            }
            Clicked?.Invoke();
        }
    }
}

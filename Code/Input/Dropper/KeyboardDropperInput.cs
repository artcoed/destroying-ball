using System;
using UnityEngine;

public class KeyboardDropperInput : MonoBehaviour, IDropperInput
{
    public event Action Pressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Pressed?.Invoke();
    }
}

using System;
using UnityEngine;

public class KeyboardMovementInput : MonoBehaviour, IMovementInput
{
    public event Action<Vector3> Pressed;

    private void Update()
    {
        var direction = Vector3.zero;

        direction.x += Input.GetKey(KeyCode.D) ? 1 : 0;
        direction.x -= Input.GetKey(KeyCode.A) ? 1 : 0;

        if (direction != Vector3.zero)
            Pressed?.Invoke(direction);
    }
}

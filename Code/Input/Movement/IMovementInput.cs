using System;
using UnityEngine;

public interface IMovementInput
{
    event Action<Vector3> Pressed;
}

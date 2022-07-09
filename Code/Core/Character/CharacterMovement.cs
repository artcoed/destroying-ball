using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private KeyboardMovementInput _input = null;

    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _borderWidth = 2.5f;

    private void Awake()
    {
        _input.Pressed += OnPressed;
    }

    private void OnDestroy()
    {
        _input.Pressed -= OnPressed;
    }

    private void OnPressed(Vector3 direction)
    {
        var position = transform.localPosition + direction * _speed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, -1 * _borderWidth, _borderWidth);
        position.z = Mathf.Clamp(position.z, -1 * _borderWidth, _borderWidth);
        transform.localPosition = position;
    }
}

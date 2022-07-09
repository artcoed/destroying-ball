using UnityEngine;

public class ItemsDropper : MonoBehaviour
{
    [SerializeField] private KeyboardDropperInput _input = null;
    [SerializeField] private Hand _hand = null;

    private void Awake()
    {
        _input.Pressed += OnPressed;
    }

    private void OnDestroy()
    {
        _input.Pressed -= OnPressed;
    }

    private void OnPressed()
    {
        if (_hand.CanDrop)
            _hand.Drop();
    }
}

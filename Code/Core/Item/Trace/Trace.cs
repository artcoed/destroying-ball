using UnityEngine;

public class Trace : MonoBehaviour
{
    [SerializeField] private Item _item = null;
    [SerializeField] private TrailRenderer _renderer = null;

    private void Awake()
    {
        _renderer.enabled = false;
    }

    private void OnEnable()
    {
        _item.Falling += OnFalling;
    }

    private void OnDisable()
    {
        _item.Falling -= OnFalling;
    }

    private void OnFalling()
    {
        _renderer.enabled = true;
    }
}

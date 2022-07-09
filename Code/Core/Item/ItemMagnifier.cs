using DG.Tweening;
using UnityEngine;

public class ItemMagnifier : MonoBehaviour
{
    [SerializeField] private Item _item = null;
    [SerializeField] private Transform _scaleTransform = null;

    [SerializeField] private Vector3 _startScale = Vector3.zero;

    [SerializeField] private Vector3 _showScale = Vector3.one;
    [SerializeField] private float _showScaleSeconds = 0.2f;

    [SerializeField] private Vector3 _fallScale = new Vector3(1f, 1f, 1f);
    [SerializeField] private float _fallScaleSeconds = 0.1f;

    [SerializeField] private Vector3 _hideScale = Vector3.zero;
    [SerializeField] private float _hideScaleSeconds = 0.1f;

    private Tween _fallScaling;

    private void Awake()
    {
        _scaleTransform.localScale = _startScale;

        _item.Showing += OnShowing;
        _item.Falling += OnFalling;
        _item.Hiding += OnHiding;
    }

    private void OnDestroy()
    {
        _item.Showing -= OnShowing;
        _item.Falling -= OnFalling;
        _item.Hiding -= OnHiding;
    }

    public void OnShowing()
    {
        _scaleTransform
            .DOScale(_showScale, _showScaleSeconds * 2)
            .OnComplete(new TweenCallback(() => _item.PrepareFall()));
    }

    public void OnFalling()
    {
        _fallScaling = _scaleTransform
            .DOScale(_fallScale, _fallScaleSeconds * 2);
    }

    public void OnHiding()
    {
        _fallScaling?.Kill();

        _scaleTransform
            .DOScale(_hideScale, _hideScaleSeconds * 2)
            .OnComplete(new TweenCallback(() => _item.Die()));
    }
}

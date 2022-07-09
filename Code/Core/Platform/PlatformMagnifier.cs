using DG.Tweening;
using UnityEngine;

public class PlatformMagnifier : MonoBehaviour
{
    [SerializeField] private Platform _platform = null;

    [SerializeField] private Vector3 _startScale = new Vector3(0, 1, 1);

    [SerializeField] private Vector3 _overlyScale = new Vector3(1.1f, 1f, 1f);
    [SerializeField] private float _overlyScaleSeconds = 0.2f;

    [SerializeField] private Vector3 _showScale = Vector3.one;
    [SerializeField] private float _showScaleSeconds = 0.1f;

    private Tween _overlyScaling;
    private Tween _showScaling;

    private void Awake()
    {
        transform.localScale = _startScale;

        _platform.Showing += OnShowing;
        _platform.Despawning += OnDespawning;
    }

    private void OnDestroy()
    {
        _platform.Showing -= OnShowing;
        _platform.Despawning -= OnDespawning;
    }

    private void OnShowing()
    {
        _overlyScaling?.Kill();
        _showScaling?.Kill();

        _overlyScaling = transform
            .DOScale(_overlyScale, _overlyScaleSeconds * 2)
            .OnComplete(new TweenCallback(() => _showScaling = transform
                .DOScale(_showScale, _showScaleSeconds * 2)));
    }

    private void OnDespawning()
    {
        transform.localScale = _startScale;
    }
}

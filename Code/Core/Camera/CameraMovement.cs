using DG.Tweening;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _camera = null;
    [SerializeField] private UpperPlatform _upperPlatform = null;

    [SerializeField] private float _speedMoveSeconds = 0.1f;

    private Tween _moving;

    private void Awake()
    {
        _upperPlatform.StartRaising += Raise;
    }

    private void OnDestroy()
    {
        _upperPlatform.StartRaising -= Raise;
    }

    private void Raise(float height)
    {
        _moving?.Kill();

        _moving = _camera
            .DOMoveY(height, _speedMoveSeconds * 2)
            .SetRelative();
    }
}

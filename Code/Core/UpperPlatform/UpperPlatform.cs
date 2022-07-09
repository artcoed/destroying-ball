using DG.Tweening;
using System;
using UnityEngine;

public class UpperPlatform : MonoBehaviour
{
    [SerializeField] private Tower _tower = null;
    [SerializeField] private float _speedRaise = 2f;
    [SerializeField] private float _height = 1.1f;

    public event Action<float> StartRaising;

    public float BottomEdgeHeight => transform.position.y - _height / 2;

    private void Awake()
    {
        _tower.PreparingTaking += Raise;
    }

    private void OnDestroy()
    {
        _tower.PreparingTaking -= Raise;
    }

    private void Raise(Platform platform)
    {
        StartRaising?.Invoke(platform.Height);

        transform
            .DOMoveY(platform.Height, platform.Height / _speedRaise)
            .SetRelative()
            .OnComplete(new TweenCallback(() => _tower.Take(platform, Vector3.up * (BottomEdgeHeight - platform.Height / 2))));
    }
}

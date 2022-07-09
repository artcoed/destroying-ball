using System;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private PlatformsPool _platformsPool = null;

    [SerializeField] private int _amountVisiblePlatforms = 10;

    private Queue<PlatformType> _takeQueue;

    private List<Platform> _visiblePlatform;

    private Platform _preparingPlatform;

    public bool CanPrepareTake => _preparingPlatform == null;

    public event Action<Platform> PreparingTaking;

    private void Awake()
    {
        _takeQueue = new();
        _visiblePlatform = new();
    }

    public void Spawn(PlatformType type)
    {
        if (CanPrepareTake)
            PrepareTake(type);
        else
            _takeQueue.Enqueue(type);
    }

    public void Take(Platform platform, Vector3 position)
    {
        if (_preparingPlatform == null)
            throw new InvalidOperationException(nameof(Take));

        if (_preparingPlatform != platform)
            throw new ArgumentException(nameof(platform));

        platform.ShowIn(position);
        _visiblePlatform.Add(platform);

        _preparingPlatform = null;

        if (_visiblePlatform.Count > _amountVisiblePlatforms)
            DropDown();

        if (_takeQueue.Count > 0)
            PrepareTake(_takeQueue.Dequeue());
    }

    private void PrepareTake(PlatformType type)
    {
        if (CanPrepareTake == false)
            throw new InvalidOperationException(nameof(PrepareTake));

        var platform = _platformsPool.Get(type);
        _preparingPlatform = platform;

        PreparingTaking?.Invoke(_preparingPlatform);
    }

    private void DropDown()
    {
        var platform = _visiblePlatform[0];
        _visiblePlatform.RemoveAt(0);
        _platformsPool.Return(platform);
    }
}

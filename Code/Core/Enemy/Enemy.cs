using DG.Tweening;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IPoolable<Enemy>
{
    [SerializeField] private float _fallSeconds = 5f;

    private PlatformsBuilder _platformsBuilder;

    private IPool<Enemy> _spawnPool;

    private bool _isClimbing;
    private bool _isFalling;

    public event Action Climbing;

    public event Action Falling;

    public bool CanFall => _isFalling == false && _isClimbing;

    public void Init(PlatformsBuilder platformsBuilder)
    {
        _platformsBuilder = platformsBuilder;
    }

    public void SpawnFrom(IPool<Enemy> pool)
    {
        _spawnPool = pool;
    }

    public void Despawn()
    {
        _isClimbing = false;
        _isFalling = false;
        gameObject.SetActive(false);
    }

    public void ClimbFrom(Vector3 position)
    {
        if (_isClimbing)
            throw new InvalidOperationException(nameof(ClimbFrom));

        _isClimbing = true;

        transform.position = position;
        gameObject.SetActive(true);

        Climbing?.Invoke();
    }

    public void Fall()
    {
        if (_isFalling)
            throw new InvalidOperationException(nameof(Fall));

        if (_isClimbing == false)
            throw new InvalidOperationException(nameof(Fall));

        _isClimbing = false;
        _isFalling = true;

        _platformsBuilder.Build();

        Falling?.Invoke();

        DOTween.Sequence()
            .AppendInterval(_fallSeconds)
            .AppendCallback(new TweenCallback(() => Die()));
    }

    public void Die()
    {
        if (_isFalling == false)
            throw new InvalidOperationException(nameof(Die));

        _isFalling = false;

        _spawnPool.Return(this);
    }
}

using System;
using UnityEngine;

public class Platform : MonoBehaviour, IPoolable<Platform>
{
    [SerializeField] private float _height = 1.1f;

    private IPool<Platform> _spawnPool;

    private bool _isShowing;

    public event Action Despawning;

    public event Action Showing;

    public float Height => _height;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void SpawnFrom(IPool<Platform> pool)
    {
        _spawnPool = pool;
    }

    public void Despawn()
    {
        _isShowing = false;
        gameObject.SetActive(false);

        Despawning?.Invoke();
    }

    public void ShowIn(Vector3 position)
    {
        if (_isShowing)
            throw new InvalidOperationException(nameof(ShowIn));

        _isShowing = true;

        transform.position = position;
        gameObject.SetActive(true);

        Showing?.Invoke();
    }

    public void Die()
    {
        if (_isShowing == false)
            throw new InvalidOperationException(nameof(Die));

        _isShowing = false;

        _spawnPool.Return(this);
    }
}

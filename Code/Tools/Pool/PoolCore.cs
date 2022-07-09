using System;
using System.Collections.Generic;

public class PoolCore<T> : IPool<T> where T : IPoolable<T>
{
    private readonly HashSet<T> _allCreatedPoolable = new();
    private readonly Queue<T> _availablePoolable = new();

    private readonly IPoolFactory<T> _factory;

    public PoolCore(IPoolFactory<T> factory)
    {
        _factory = factory;
    }

    public T Get()
    {
        if (_availablePoolable.Count > 0)
            return _availablePoolable.Dequeue();

        var createdPoolable = _factory.Create();
        _allCreatedPoolable.Add(createdPoolable);
        return createdPoolable;
    }

    public void Return(T poolable)
    {
        if (_allCreatedPoolable.Contains(poolable) == false)
            throw new ArgumentException(nameof(poolable));

        _availablePoolable.Enqueue(poolable);
        poolable.Despawn();
    }
}

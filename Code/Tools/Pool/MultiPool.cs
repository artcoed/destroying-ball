using System.Collections.Generic;

public class MultiPool<TKey, TPoolable> : IPool<TPoolable> where TPoolable : IPoolable<TPoolable>
{
    private readonly Dictionary<TKey, PoolCore<TPoolable>> _pools = new();

    private readonly Dictionary<TPoolable, TKey> _busyObjects = new();

    public void AddPool(TKey key, IPoolFactory<TPoolable> factory)
    {
        _pools.Add(key, new(factory));
    }

    public TPoolable Get(TKey key)
    {
        var poolable = _pools[key].Get();
        _busyObjects.Add(poolable, key);
        poolable.SpawnFrom(this);
        return poolable;
    }

    public void Return(TPoolable poolable)
    {
        var key = _busyObjects[poolable];
        _busyObjects.Remove(poolable);
        _pools[key].Return(poolable);
    }
}

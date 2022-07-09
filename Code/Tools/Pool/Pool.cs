public class Pool<T> : IPool<T> where T : IPoolable<T>
{
    private readonly PoolCore<T> _poolCore;

    public Pool(IPoolFactory<T> factory)
    {
        _poolCore = new(factory);
    }

    public T Get()
    {
        var polable = _poolCore.Get();
        polable.SpawnFrom(this);
        return polable;
    }

    public void Return(T poolable)
    {
        _poolCore.Return(poolable);
    }
}

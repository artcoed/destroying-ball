public interface IPoolable<T> where T : IPoolable<T>
{
    void SpawnFrom(IPool<T> pool);

    void Despawn();
}

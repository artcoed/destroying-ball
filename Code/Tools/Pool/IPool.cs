public interface IPool<T> where T : IPoolable<T>
{
    void Return(T poolable);
}

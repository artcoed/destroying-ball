public interface IPoolFactory<T> where T : IPoolable<T>
{
    T Create();
}

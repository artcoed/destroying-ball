using UnityEngine;

public class EnemiesPool : MonoBehaviour
{
    [SerializeField] private DefaultEnemiesFactory _defaultEnemiesFactory = null;

    private MultiPool<EnemyType, Enemy> _multiPool;

    private void Awake()
    {
        _multiPool = new();
        _multiPool.AddPool(EnemyType.Default, _defaultEnemiesFactory);
    }

    public Enemy Get(EnemyType type)
    {
        return _multiPool.Get(type);
    }

    public void Return(Enemy enemy)
    {
        _multiPool.Return(enemy);
    }
}

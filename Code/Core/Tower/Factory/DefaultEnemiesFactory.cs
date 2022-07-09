using UnityEngine;

public class DefaultEnemiesFactory : MonoBehaviour, IPoolFactory<Enemy>
{
    [SerializeField] private Enemy _prefab = null;

    public Enemy Create()
    {
        return Instantiate(_prefab);
    }
}

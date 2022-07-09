using UnityEngine;

public class DefaultEnemiesFactory : MonoBehaviour, IPoolFactory<Enemy>
{
    [SerializeField] private Enemy _prefab = null;

    private int i;

    public Enemy Create()
    {
        print($"������: {++i}");
        return Instantiate(_prefab);
    }
}

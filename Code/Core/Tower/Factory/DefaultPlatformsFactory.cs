using UnityEngine;

public class DefaultPlatformsFactory : MonoBehaviour, IPoolFactory<Platform>
{
    [SerializeField] private Platform _prefab = null;

    private int i;

    public Platform Create()
    {
        print($"��������: {++i}");
        return Instantiate(_prefab);
    }
}

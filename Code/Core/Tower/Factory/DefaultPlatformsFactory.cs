using UnityEngine;

public class DefaultPlatformsFactory : MonoBehaviour, IPoolFactory<Platform>
{
    [SerializeField] private Platform _prefab = null;

    public Platform Create()
    {
        return Instantiate(_prefab);
    }
}

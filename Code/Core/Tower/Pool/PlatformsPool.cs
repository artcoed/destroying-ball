using UnityEngine;

public class PlatformsPool : MonoBehaviour
{
    [SerializeField] private DefaultPlatformsFactory _defaultPlatformsFactory = null;

    private MultiPool<PlatformType, Platform> _multiPool;

    private void Awake()
    {
        _multiPool = new();
        _multiPool.AddPool(PlatformType.Default, _defaultPlatformsFactory);
    }

    public Platform Get(PlatformType type)
    {
        return _multiPool.Get(type);
    }

    public void Return(Platform platform)
    {
        _multiPool.Return(platform);
    }
}

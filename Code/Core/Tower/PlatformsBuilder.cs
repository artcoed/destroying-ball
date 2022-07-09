using UnityEngine;

public class PlatformsBuilder : MonoBehaviour
{
    [SerializeField] private Tower _tower = null;

    [SerializeField] private PlatformType _platformType = PlatformType.Default;

    public void Build()
    {
        _tower.Spawn(_platformType);
    }
}

using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private EnemiesPool _pool = null;
    [SerializeField] private PlatformsBuilder _platformsBuilder = null;
    [SerializeField] private UpperPlatform _upperPlatform = null;

    [SerializeField] private EnemyType _type = EnemyType.Default;
    [SerializeField] private float _delaySeconds = 2f;

    [SerializeField] private Vector3 _minimumPosition = new Vector3(-2, 0, 0);
    [SerializeField] private Vector3 _maximumPosition = new Vector3(2, 0, 0);

    private float _elapsedSeconds;

    private void Awake()
    {
        _upperPlatform.StartRaising += OnStartRaising;
    }

    private void OnDestroy()
    {
        _upperPlatform.StartRaising -= OnStartRaising;
    }

    private void Update()
    {
        _elapsedSeconds += Time.deltaTime;
        if (_elapsedSeconds >= _delaySeconds)
        {
            _elapsedSeconds = 0;
            var enemy = _pool.Get(_type);
            enemy.Init(_platformsBuilder);
            enemy.ClimbFrom(_minimumPosition.Random(_maximumPosition));
        }
    }

    private void OnStartRaising(float height)
    {
        _minimumPosition.y += height;
        _maximumPosition.y += height;
    }
}

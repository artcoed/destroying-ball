using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private Hand _hand = null;
    [SerializeField] private Item _itemPrefab = null;

    [SerializeField] private float _delaySeconds = 4f;

    private float _elapsedSeconds;

    private void Update()
    {
        if (_hand.CanTake)
        {
            _elapsedSeconds += Time.deltaTime;
            if (_elapsedSeconds >= _delaySeconds)
            {
                _elapsedSeconds = 0;
                _hand.Take(Instantiate(_itemPrefab));
            }
        }
    }
}

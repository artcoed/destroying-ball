using System.Collections;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    [SerializeField] private Item _item = null;

    [SerializeField] private float _fallSpeed = 10f;

    private Coroutine _falling;

    private void Awake()
    {
        _item.Falling += OnFalling;
    }

    private void OnDestroy()
    {
        _item.Falling -= OnFalling;
    }

    private void OnFalling()
    {
        if (_falling != null)
            StopCoroutine(_falling);

        _falling = StartCoroutine(Falling());
    }

    private IEnumerator Falling()
    {
        while (true)
        {
            transform.position += Vector3.down * _fallSpeed * Time.deltaTime;
            yield return null;
        }
    }
}

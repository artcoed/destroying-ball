using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Enemy _enemy = null;

    [SerializeField] private float _climbingSpeed = 2f;
    [SerializeField] private float _fallingSpeed = 4f;

    private Coroutine _climbing;
    private Coroutine _falling;

    private void Awake()
    {
        _enemy.Climbing += OnClimbing;
        _enemy.Falling += OnFalling;
    }

    private void OnDestroy()
    {
        _enemy.Climbing -= OnClimbing;
        _enemy.Falling -= OnFalling;
    }

    private void OnClimbing()
    {
        StopMovings();
        _climbing = StartCoroutine(Climbing());
    }

    private void OnFalling()
    {
        StopMovings();
        _falling = StartCoroutine(Falling());
    }

    private void StopMovings()
    {
        if (_climbing != null)
            StopCoroutine(_climbing);

        if (_falling != null)
            StopCoroutine(_falling);
    }

    private IEnumerator Climbing()
    {
        while (true)
        {
            transform.position += Vector3.up * _climbingSpeed * Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator Falling()
    {
        while (true)
        {
            transform.position += Vector3.down * _fallingSpeed * Time.deltaTime;
            yield return null;
        }
    }
}

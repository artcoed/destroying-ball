using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ItemWeapon : MonoBehaviour
{
    [SerializeField] private Item _item = null;

    [SerializeField] private float _rangeAttack = 0.3f;
    [SerializeField] private float _maxAttackSeconds = 5f;

    private Coroutine _attacking;

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
        if (_attacking != null)
            StopCoroutine(_attacking);

        _attacking = StartCoroutine(Attacking());
    }

    private IEnumerator Attacking()
    {
        var elapsedSeconds = 0f;

        while (true)
        {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds >= _maxAttackSeconds)
            {
                _item.Hide();
                yield break;
            }

            var hits = Physics.OverlapSphere(transform.position, _rangeAttack);
            foreach (var hit in hits)
            {
                if (hit.TryGetComponent<Enemy>(out var enemy) && enemy.CanFall)
                {
                    enemy.Fall();
                    _item.Hide();
                    yield break;
                }
            }

            yield return null;
        }
    }
}

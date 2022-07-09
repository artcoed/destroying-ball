using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator = null;
    [SerializeField] private Enemy _enemy = null;

    [SerializeField] private string _climbAnimation = "Climb";
    [SerializeField] private string _fallAnimation = "Fall";

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
        _animator.Play(_climbAnimation);
    }

    private void OnFalling()
    {
        _animator.Play(_fallAnimation);
    }
}

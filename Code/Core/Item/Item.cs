using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    private bool _isShowing;
    private bool _canFall;
    private bool _isFalling;
    private bool _isHyding;

    public event Action Showing;

    public event Action Falling;

    public event Action Hiding;

    public bool CanFall => _canFall;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        if (_isShowing)
            throw new InvalidOperationException(nameof(Show));

        _isShowing = true;
        gameObject.SetActive(true);

        Showing?.Invoke();
    }

    public void PrepareFall()
    {
        if (_canFall)
            throw new InvalidOperationException(nameof(PrepareFall));

        if (_isShowing == false)
            throw new InvalidOperationException(nameof(PrepareFall));

        _isShowing = false;
        _canFall = true;
    }

    public void Fall()
    {
        if (_isFalling)
            throw new InvalidOperationException(nameof(Fall));

        if (_canFall == false)
            throw new InvalidOperationException(nameof(Fall));

        _canFall = false;
        _isFalling = true;

        Falling?.Invoke();
    }

    public void Hide()
    {
        if (_isHyding)
            throw new InvalidOperationException(nameof(Hide));

        if (_isFalling == false)
            throw new InvalidOperationException(nameof(Hide));

        _isFalling = false;
        _isHyding = true;

        Hiding?.Invoke();
    }

    public void Die()
    {
        if (_isHyding == false)
            throw new InvalidOperationException(nameof(Die));

        _isHyding = false;

        Destroy(gameObject);
    }
}

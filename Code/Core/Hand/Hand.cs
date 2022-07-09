using System;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private Item _item;

    public bool CanDrop => HasItem && _item.CanFall;

    public bool CanTake => HasItem == false;

    private bool HasItem => _item != null;

    public void Take(Item item)
    {
        if (CanTake == false)
            throw new InvalidOperationException(nameof(Take));

        _item = item;
        _item.transform.SetParent(transform);
        _item.transform.localPosition = Vector3.zero;
        _item.Show();
    }

    public void Drop()
    {
        if (CanDrop == false)
            throw new InvalidOperationException(nameof(Drop));

        _item.transform.SetParent(null);
        _item.Fall();
        _item = null;
    }
}

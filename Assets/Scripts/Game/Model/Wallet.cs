using System;
using UnityEngine.Events;

[Serializable]
public class Wallet
{
    public readonly UnityEvent<Wallet> CountChanged = new UnityEvent<Wallet>();

    private int _count;
    public int count
    {
        get => _count;
        set
        {
            _count = Math.Max(0, value);
            CountChanged?.Invoke(this);
        }
    }
}

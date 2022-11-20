using UnityEngine;

public class WeaponScreen : UIScreen
{
    [SerializeField] private WeaponScreenElement a;
    [SerializeField] private WeaponScreenElement b;

    public void Init(WeaponDisplayComponent a, WeaponDisplayComponent b)
    {
        this.a.Init(a);
        this.b.Init(b);
    }
}

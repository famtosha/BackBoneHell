using System;
using UnityEngine;
using UnityTools;

[Serializable]
public class WeaponModel
{
    public Timer shootCD { get; private set; }
    public WeaponData data { get; private set; }

    public WeaponDisplayComponent view { get; set; }

    public Sprite displaySprite => data.discplaySprite;

    public WeaponModel(WeaponData data)
    {
        this.data = data;
        this.shootCD = new Timer(this.data.shootDelay);
    }

    public void Shoot()
    {
        data.shootingStrategy.Shoot(view);
    }
}

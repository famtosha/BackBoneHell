using System;
using UnityEngine;

[Serializable]
public abstract class ShootingStrategy
{
    public abstract void Shoot(WeaponDisplayComponent view);

    protected WeaponProjectileComponent SpawnProjectile(WeaponProjectileComponent projectile)
    {
        var clone = GameObject.Instantiate(projectile);
        GameObject.FindObjectOfType<WeaponProjectileSystem>().RegisterProjectile(clone);
        return clone;
    }
}

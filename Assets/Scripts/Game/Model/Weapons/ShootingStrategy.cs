using System;
using UnityEngine;

[Serializable]
public abstract class ShootingStrategy
{
    public abstract void Shoot(WeaponDisplayComponent view, bool players);

    protected ProjectileComponent SpawnProjectile(ProjectileComponent projectile)
    {
        var clone = GameObject.Instantiate(projectile);
        GameObject.FindObjectOfType<ProjectileSystem>().RegisterProjectile(clone);
        return clone;
    }
}

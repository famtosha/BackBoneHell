using System;
using UnityEngine;

[Serializable]
public class DefaulShootingStrategy : ShootingStrategy
{
    [SerializeField] private WeaponProjectileComponent _projectile;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    public override void Shoot(WeaponDisplayComponent view)
    {
        var clone = SpawnProjectile(_projectile);
        clone.transform.position = view.shootingOrigin.position;
        clone.transform.up = view.shootingOrigin.up;
        clone.Init(_speed, _damage);
    }
}

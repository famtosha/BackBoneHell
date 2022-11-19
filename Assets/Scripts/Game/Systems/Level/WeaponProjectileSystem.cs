using UnityEngine;

public class WeaponProjectileSystem : GameSystem
{
    public override void OnUpdate()
    {
        gameData.projectiles.ForEach(x => x.OnUpdate());
    }

    public void RegisterProjectile(WeaponProjectileComponent projectile)
    {
        gameData.projectiles.Add(projectile);
        projectile.TriggerEntered.AddListener(OnProjectileCollide);
    }

    public void RemoveProjectile(WeaponProjectileComponent projectile)
    {
        projectile.TriggerEntered.RemoveListener(OnProjectileCollide);
        projectile.ShowDestroy();
    }

    private void OnProjectileCollide(WeaponProjectileComponent projectile, Collider2D other)
    {
        if (other.TryGetComponent(out WallComponent wall))
        {
            RemoveProjectile(projectile);
        }
        if (projectile.players)
        {
            if (other.TryGetComponent(out EnemyComponent enemy))
            {
                enemy.ApplyDamage(projectile.damage);
                RemoveProjectile(projectile);
            }
        }
        else
        {
            if (other.TryGetComponent(out PlayerComponent enemy))
            {
                RemoveProjectile(projectile);
            }
        }
    }
}

using UnityEngine;

public class ProjectileSystem : GameSystem
{
    public override void OnUpdate()
    {
        gameData.projectiles.ForEach(x => x.OnUpdate());
    }

    public void RegisterProjectile(ProjectileComponent projectile)
    {
        gameData.projectiles.Add(projectile);
        projectile.TriggerEntered.AddListener(OnProjectileCollide);
    }

    public void RemoveProjectile(ProjectileComponent projectile)
    {
        projectile.TriggerEntered.RemoveListener(OnProjectileCollide);
        projectile.ShowDestroy();
        gameData.projectiles.Remove(projectile);
    }

    private void OnProjectileCollide(ProjectileComponent projectile, Collider2D other)
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

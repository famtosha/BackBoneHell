using UnityEngine;

public class ShootSystem : GameSystem
{
    private WeaponModel firstWeapon => gameData.player.aimRoot.a.linkedWeapon;
    private WeaponModel secondWeapon => gameData.player.aimRoot.b.linkedWeapon;

    public override void OnUpdate()
    {
        if (Input.GetMouseButton(0)) ProduceWeapon(firstWeapon);
        if (Input.GetMouseButton(1)) ProduceWeapon(secondWeapon);
    }

    private void ProduceWeapon(WeaponModel weapon)
    {
        if (weapon == null) return;
        weapon.shootCD.UpdateTimer();
        if (weapon.shootCD.isReady)
        {
            weapon.Shoot(true);
            weapon.shootCD.Reset();
        }
    }
}

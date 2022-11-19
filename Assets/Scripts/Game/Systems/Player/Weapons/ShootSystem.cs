using UnityEngine;

public class ShootSystem : GameSystem
{
    private WeaponModel activeWeapon => gameData.player.aimRoot.activeWeapon.linkedWeapon;

    public override void OnUpdate()
    {
        if (activeWeapon == null) return;
        activeWeapon.shootCD.UpdateTimer();
        if (Input.GetMouseButton(0) && activeWeapon.shootCD.isReady)
        {
            activeWeapon.Shoot();
            activeWeapon.shootCD.Reset();
        }
    }
}

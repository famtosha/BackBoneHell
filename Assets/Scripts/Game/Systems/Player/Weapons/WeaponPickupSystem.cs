using System.Collections.Generic;

public class WeaponPickupSystem : GameSystem
{
    private List<WorldWeaponComponent> weapons => gameData.woldWeaponComponents;
    private PlayerComponent player => gameData.player;

    public override void Enabled()
    {
        weapons.ForEach(x => x.PlayerEntered.AddListener(OnPlayerEntered));
    }

    public override void Disable()
    {
        weapons.ForEach(x => x.PlayerEntered.RemoveListener(OnPlayerEntered));
    }

    public override void OnStart()
    {
        player.aimRoot.a.RemoveWeapon();
        player.aimRoot.b.RemoveWeapon();
    }

    private void OnPlayerEntered(WorldWeaponComponent weaponComponent)
    {
        player.aimRoot.a.SetWeapon(new WeaponModel(weaponComponent.weapon));
        Destroy(weaponComponent.gameObject);
    }
}

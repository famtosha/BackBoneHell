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
        player.aimRoot.a.sprite.sprite = null;
        player.aimRoot.b.sprite.sprite = null;
    }

    private void OnPlayerEntered(WorldWeaponComponent weapon)
    {
        player.aimRoot.a.sprite.sprite = weapon.weapon.discplaySprite;
        Destroy(weapon.gameObject);
    }
}

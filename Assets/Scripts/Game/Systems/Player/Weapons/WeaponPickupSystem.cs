using System.Collections.Generic;
using UnityEngine;

public class WeaponPickupSystem : GameSystem
{
    private List<WorldWeaponComponent> weapons => gameData.woldWeaponComponents;
    private PlayerComponent player => gameData.player;

    private WeaponScreen _screen;

    public override void OnStateEnter()
    {
        weapons.ForEach(x => x.PlayerEntered.AddListener(OnPlayerEntered));
    }

    public override void OnStateExit()
    {
        weapons.ForEach(x => x.PlayerEntered.RemoveListener(OnPlayerEntered));
    }

    public override void OnStart()
    {
        _screen = FindObjectOfType<UISolver>().Get<WeaponScreen>();
        _screen.Open();
        _screen.Init(player.aimRoot.a, player.aimRoot.b);
        player.aimRoot.a.RemoveWeapon();
        player.aimRoot.b.RemoveWeapon();
    }

    private void OnPlayerEntered(WorldWeaponComponent weaponComponent)
    {
        player.aimRoot.a.SetWeapon(new WeaponModel(weaponComponent.weapon));
        Destroy(weaponComponent.gameObject);
    }
}
